using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using WpfCamera.Enums;

namespace WpfCamera;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private VideoCapture? _capture;
    private DispatcherTimer? _timer;
    private Mat _currentFrame = new();
    private Hsv _selectedHsvColor;
    private bool _isColorSelected = false;

    public MainWindow()
    {
        InitializeCamera();
        InitializeComponent();
        SetupFilterComboBox();
    }

    private void InitializeCamera()
    {
        _capture = new VideoCapture();
        _capture.ImageGrabbed += ProcessFrame;

        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(30)
        };
        _timer.Tick += (sender, args) => { _capture.Grab(); };
        _timer.Start();
    }
    
    private void SetupFilterComboBox()
    {
        FilterComboBox.ItemsSource = Enum.GetValues(typeof(FilterType))
            .Cast<FilterType>()
            .Select(e => new { Key = e, Value = e.ToString() })
            .ToList();
        FilterComboBox.DisplayMemberPath = "Value";
        FilterComboBox.SelectedValuePath = "Key";
        FilterComboBox.SelectedIndex = 0;
    }

    private void ProcessFrame(object? sender, EventArgs e)
    {
        _capture?.Retrieve(_currentFrame);
        
        AdjustBrightness();
        ApplyFilter();

        if (_isColorSelected)
        {
            HighlightSimilarColors(_selectedHsvColor);
        }
        
        ApplyEdgeDetection();
        
        var bitmap = _currentFrame.ToBitmap();
        Dispatcher.Invoke(() => { CameraImage.Source = BitmapToBitmapImage(bitmap); });
    }
    
    private void ApplyEdgeDetection()
    {
        var control = EdgeDetectionCustomControl;
        if (!control.IsEdgeDetectionEnabled) return;
        
        var grayFrame = new Mat();
        CvInvoke.CvtColor(_currentFrame, grayFrame, ColorConversion.Bgr2Gray);
        CvInvoke.GaussianBlur(grayFrame, grayFrame, new System.Drawing.Size(3, 3), 0);
            
        var cannyFrame = new Mat();
        CvInvoke.Canny(grayFrame, cannyFrame, control.Threshold, control.ThresholdLinking);

        _currentFrame = cannyFrame;
    }
    
    private void AdjustBrightness()
    {
        var brightness = EdgeDetectionCustomControl.Brightness;
        if (brightness != 0)
        {
            _currentFrame.ConvertTo(_currentFrame, DepthType.Cv8U, 1, brightness);
        }
    }

    private void ApplyFilter()
    {
        if (FilterComboBox.SelectedValue is FilterType selectedFilter)
        {
            switch (selectedFilter)
            {
                case FilterType.Gaussian:
                    CvInvoke.GaussianBlur(_currentFrame, _currentFrame,
                        new System.Drawing.Size(GaussianFilterCustomControl.KernelSize,
                            GaussianFilterCustomControl.KernelSize), 0);
                    break;
                case FilterType.Median:
                    CvInvoke.MedianBlur(_currentFrame, _currentFrame, MedianFilterCustomControl.KernelSize);
                    break;
                case FilterType.Bilateral:
                    if (_currentFrame.NumberOfChannels == 1)
                    {
                        CvInvoke.CvtColor(_currentFrame, _currentFrame, ColorConversion.Gray2Bgr);
                    }
                    else if (_currentFrame.NumberOfChannels == 4)
                    {
                        CvInvoke.CvtColor(_currentFrame, _currentFrame, ColorConversion.Bgra2Bgr);
                    }

                    Mat dst = new Mat();
                    CvInvoke.BilateralFilter(_currentFrame, dst, BilateralFilterCustomControl.Diameter,
                        BilateralFilterCustomControl.SigmaColor, BilateralFilterCustomControl.SigmaSpace);
                    _currentFrame = dst;
                    break;
                case FilterType.NoFilter:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    
    private static BitmapImage BitmapToBitmapImage(System.Drawing.Image bitmap)
    {
        using var memory = new MemoryStream();
        bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
        memory.Position = 0;
        var bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = memory;
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.EndInit();
        bitmapImage.Freeze();
        return bitmapImage;
    }

    private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        GaussianFilterCustomControl.Visibility = Visibility.Collapsed;
        MedianFilterCustomControl.Visibility = Visibility.Collapsed;
        BilateralFilterCustomControl.Visibility = Visibility.Collapsed;

        if (FilterComboBox.SelectedValue is FilterType selectedFilter)
        {
            switch (selectedFilter)
            {
                case FilterType.Gaussian:
                    GaussianFilterCustomControl.Visibility = Visibility.Visible;
                    break;
                case FilterType.Median:
                    MedianFilterCustomControl.Visibility = Visibility.Visible;
                    break;
                case FilterType.Bilateral:
                    BilateralFilterCustomControl.Visibility = Visibility.Visible;
                    break;
                case FilterType.NoFilter:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void CameraImage_MouseMove(object sender, MouseEventArgs e)
    {
        var position = e.GetPosition(CameraImage);

        var imagePosition = new System.Drawing.Point(
            (int)position.X,
            (int)position.Y);

        DrawCrosshair(imagePosition);

        DisplayPixelInfo(imagePosition);
    }

    private void DrawCrosshair(System.Drawing.Point position)
    {
        DrawingCanvas.Children.Clear();
        
        var horizontalLine = new Line
        {
            X1 = 0,
            Y1 = position.Y,
            X2 = DrawingCanvas.ActualWidth,
            Y2 = position.Y,
            Stroke = System.Windows.Media.Brushes.Red,
            StrokeThickness = 1
        };
        
        var verticalLine = new Line
        {
            X1 = position.X,
            Y1 = 0,
            X2 = position.X,
            Y2 = DrawingCanvas.ActualHeight,
            Stroke = System.Windows.Media.Brushes.Green,
            StrokeThickness = 1
        };
        
        DrawingCanvas.Children.Add(horizontalLine);
        DrawingCanvas.Children.Add(verticalLine);
    }

    private void CameraImage_MouseLeave(object sender, MouseEventArgs e)
    {
        DrawingCanvas.Children.Clear();
        _isColorSelected = false;
    }
    
    private void CameraImage_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var position = e.GetPosition(CameraImage);

        var imagePosition = new System.Drawing.Point(
            (int)position.X,
            (int)position.Y);
        
        Bgr pixelColor = GetPixelColor(imagePosition);
        _selectedHsvColor = ConvertBgrToHsv(pixelColor);
        _isColorSelected = true;
    }

    private void DisplayPixelInfo(System.Drawing.Point position)
    {
        var color = _currentFrame.ToImage<Bgr, byte>()[position.Y, position.X];
        PixelInfo.UpdatePixelInfo(position,
            Color.FromArgb(255, (int)color.Red, (int)color.Green, (int)color.Blue));
    }
    
    private Bgr GetPixelColor(System.Drawing.Point position)
    {
        var data = _currentFrame.GetData();
        var x = position.X;
        var y = position.Y;
        
        if (x >= 0 && y >= 0 && x < _currentFrame.Width && y < _currentFrame.Height)
        {
            var blue = Convert.ToDouble(data.GetValue(y,x,0));
            var green = Convert.ToDouble(data.GetValue(y,x,1));
            var red = Convert.ToDouble(data.GetValue(y,x,2));

            var color = new Bgr(blue, green, red);
            return color;
        }
        return new Bgr(0, 0, 0);
    }
    
    private void HighlightSimilarColors(Hsv targetHsv)
    {
        Mat hsvImage = new Mat();
        CvInvoke.CvtColor(_currentFrame, hsvImage, ColorConversion.Bgr2Hsv);
        
        ScalarArray lowerBound = new ScalarArray(new MCvScalar(targetHsv.Hue - 10, targetHsv.Satuation - 40, targetHsv.Value - 40));
        ScalarArray upperBound = new ScalarArray(new MCvScalar(targetHsv.Hue + 10, targetHsv.Satuation + 40, targetHsv.Value + 40));

        Mat mask = new Mat();
        CvInvoke.InRange(hsvImage, lowerBound, upperBound, mask);
        
        Mat resultImage = new Mat();
        CvInvoke.BitwiseAnd(_currentFrame, _currentFrame, resultImage, mask);
        
        _currentFrame = resultImage;
    }
    
    private Hsv ConvertBgrToHsv(Bgr bgrColor)
    {
        using (Image<Bgr, byte> bgrImage = new Image<Bgr, byte>(1, 1, bgrColor))
        {
            Image<Hsv, byte> hsvImage = bgrImage.Convert<Hsv, byte>();
            Hsv hsvColor = hsvImage[0, 0];
            return hsvColor;
        }
    }

}