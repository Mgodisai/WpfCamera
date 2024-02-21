using System.Windows.Media;

namespace WpfCamera.Controls;

public partial class PixelInfoControl
{
    public PixelInfoControl()
    {
        InitializeComponent();
    }

    public void UpdatePixelInfo(System.Drawing.Point coordinates, System.Drawing.Color color)
    {
        CoordinatesText.Text = $"X,Y: {coordinates.X}, {coordinates.Y}";
        RgbText.Text = $"RGB: {color.R}, {color.G}, {color.B}";
        ColorPreview.Fill = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
    }
}