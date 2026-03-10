namespace CodingDropletsMauiApp.Controls;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();
	}

    private void Btn_CommonControl_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new CommonControls());
    }

    private void Btn_ActionsControl_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ActionsPage());
    }

    private void Btn_InputControl_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new InputControls());
    }

    private void Btn_IndicatorControl_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new IndicatorControls());
    }

    private void Btn_DrawingControl_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DrawingControls());
    }

    private void Btn_CarousalDemo_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CourouselViewDemo());
    }

    private void Btn_ListViewDemo_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ListViewDemo());
    }

    private void Btn_CollectionViewDemo_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CollectionViewDemo());
    }
}