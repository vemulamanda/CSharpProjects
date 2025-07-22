namespace CodingDropletsMauiApp.Pages.NavPageDemo;

public partial class NavContentPage3 : ContentPage
{
	public NavContentPage3()
	{
		InitializeComponent();
	}

    private void BtnPrv_NavContentpage03_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}