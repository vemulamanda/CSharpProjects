using Microsoft.Maui.Controls;

namespace CodingDropletsMauiApp.Controls;

public partial class IndicatorControls : ContentPage
{
	public IndicatorControls()
	{
		InitializeComponent();
	}

    private void Btn_ActivityIndicator_Clicked(object sender, EventArgs e)
    {
        activityindicator.IsRunning = !activityindicator.IsRunning;
    }
}