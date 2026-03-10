namespace CodingDropletsMauiApp.Controls;

public partial class InputControls : ContentPage
{
	public InputControls()
	{
		InitializeComponent();
	}

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        sliderValuelabel.Text = ((int)e.NewValue).ToString();
    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        DisplayAlert("Stepper value", $"Value: {e.NewValue}", "OK");
    }
}