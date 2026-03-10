namespace SudMauiApp.Pages;

public partial class DisplaySingleImage : ContentPage
{
	public DisplaySingleImage(ImageSource singleimage)
	{
		InitializeComponent();
		BindingContext = singleimage;
	}
}