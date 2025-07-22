using System.Threading.Tasks;

namespace CodingDropletsMauiApp.Pages;

public partial class DemoContentPage2 : ContentPage
{
	public DemoContentPage2()
	{
		InitializeComponent();
	}

    private async void BtnNxt_Contentpage02_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new DemoContentPage3());
    }

    private async void BtnPrv_Contentpage02_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}