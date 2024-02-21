using System.Windows;

namespace WpfCamera.Controls;

public partial class GaussianFilterControl
{
    public static readonly DependencyProperty KernelSizeProperty =
        DependencyProperty.Register("KernelSize", typeof(int), typeof(GaussianFilterControl), new PropertyMetadata(5));

    public int KernelSize => (int)GetValue(KernelSizeProperty);

    public GaussianFilterControl()
    {
        InitializeComponent();
        DataContext = this;
    }
}