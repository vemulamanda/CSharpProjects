namespace CodingDropletsMauiApp.Controls;

public partial class ActionsPage : ContentPage
{
	public ActionsPage()
	{
		InitializeComponent();
	}

    private void actionControl_Clicked(object sender, EventArgs e)
    {
		DisplayAlert("Information", "Thank you for clicking on me", "OK");
    }

    private void btn_ImagebtnControl_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Information", "Thank you for Downloading our site", "OK");
    }

    private void demosearchbar_SearchButtonPressed(object sender, EventArgs e)
    {
        DisplayAlert("Information", $"You have searched for {demosearchbar.Text}", "OK");
    }

    private void facebook_swipeitem_Invoked(object sender, EventArgs e)
    {
        DisplayAlert("Information", "Thank you for using Facebook", "OK");
    }

    private void instagram_swipeitem_Invoked(object sender, EventArgs e)
    {
        DisplayAlert("Information", "Thank you for using Instagram", "OK");
    }

    private void twitter_swipeitem_Invoked(object sender, EventArgs e)
    {
        DisplayAlert("Information", "Thank you for Twitter", "OK");
    }

    private void twitterrightitem_Invoked(object sender, EventArgs e)
    {
        DisplayAlert("Information", "Thank you for Twitter", "OK");
    }
}