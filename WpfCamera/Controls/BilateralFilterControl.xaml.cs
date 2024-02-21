using System.Windows;

namespace WpfCamera.Controls;

public partial class BilateralFilterControl
{
    public static readonly DependencyProperty DiameterProperty =
        DependencyProperty.Register("Diameter", typeof(int), typeof(BilateralFilterControl), new PropertyMetadata(9));

    public int Diameter => (int)GetValue(DiameterProperty); 
    
    public static readonly DependencyProperty SigmaColorProperty =
        DependencyProperty.Register("SigmaColor", typeof(double), typeof(BilateralFilterControl), new PropertyMetadata(75.0));

    public double SigmaColor => (double)GetValue(SigmaColorProperty);

    public static readonly DependencyProperty SigmaSpaceProperty =
        DependencyProperty.Register("SigmaSpace", typeof(double), typeof(BilateralFilterControl), new PropertyMetadata(75.0));

    public double SigmaSpace => (double)GetValue(SigmaSpaceProperty);

    public BilateralFilterControl()
    {
        InitializeComponent();
        DataContext = this;
    }
}