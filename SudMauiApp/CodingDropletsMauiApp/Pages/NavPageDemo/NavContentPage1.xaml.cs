using Android.Content.Res;

namespace CodingDropletsMauiApp.Pages.NavPageDemo;

public partial class NavContentPage1 : ContentPage
{
	public NavContentPage1()
	{
		InitializeComponent();
	}

    private async void BtnNxt_NavContentpage01_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NavContentPage2());
    }
}