namespace WpfCamera.Controls;

public partial class EdgeDetectionControl
{
    public EdgeDetectionControl()
    {
        InitializeComponent();
    }
    
    public double Brightness => BrightnessSlider.Value;
    public double Threshold => ThresholdSlider.Value;
    public double ThresholdLinking => ThresholdLinkingSlider.Value;
    public bool IsEdgeDetectionEnabled => EdgeDetectionCheckBox.IsChecked == true;
}