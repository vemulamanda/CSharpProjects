namespace CodingDropletsMauiApp.Pages.NavPageDemo;

public partial class NavContentPage2 : ContentPage
{
	public NavContentPage2()
	{
		InitializeComponent();
	}

    private async void BtnNxt_NavContentpage02_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NavContentPage3());
    }

    private async void BtnPrv_NavContentpage02_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}