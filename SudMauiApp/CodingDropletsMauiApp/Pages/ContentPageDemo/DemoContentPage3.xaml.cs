using System.Threading.Tasks;

namespace CodingDropletsMauiApp.Pages;

public partial class DemoContentPage3 : ContentPage
{
	public DemoContentPage3()
	{
		InitializeComponent();
	}

    private async void BtnPrv_Contentpage03_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}