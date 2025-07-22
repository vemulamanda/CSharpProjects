using System.Threading.Tasks;

namespace CodingDropletsMauiApp.Pages;

public partial class DemoContentPage1 : ContentPage
{
	public DemoContentPage1()
	{
		InitializeComponent();
	}

    private async void BtnNxt_Contentpage01_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new DemoContentPage2()); //to navigate to another page
    }

    private async void BtnPrv_Contentpage01_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();  //to navigate to previous opened page. This popmodalasync doesnt create a new instance of page. it just navigates.
    }
}