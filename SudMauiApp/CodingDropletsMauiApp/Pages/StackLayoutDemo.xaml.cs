namespace CodingDropletsMauiApp.Pages;

public partial class StackLayoutDemo : ContentPage
{
	public StackLayoutDemo()
	{
		InitializeComponent();
	}

    private void verticalStackLayoutButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new VerticalStackLayoutDemo());
    }

    private void horizontalStackLayout_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HorizontalStackLayout());
    }

    private void gridLayout_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GridDemo());
    }

    private void absoluteLayout_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AbsoluteLayoutDemo());
    }

    private void flexLayout_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FlexLayout());
    }
}