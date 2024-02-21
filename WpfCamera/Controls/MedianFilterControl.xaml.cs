using System.Windows;

namespace WpfCamera.Controls;

public partial class MedianFilterControl
{
    public static readonly DependencyProperty KernelSizeProperty =
        DependencyProperty.Register("KernelSize", typeof(int), typeof(MedianFilterControl), new PropertyMetadata(3));

    public int KernelSize => (int)GetValue(KernelSizeProperty);
    
    public MedianFilterControl()
    {
        InitializeComponent();
        DataContext = this;
    }
}