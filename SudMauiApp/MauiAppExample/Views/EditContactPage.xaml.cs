namespace MauiAppExample.Views;

public partial class EditContactPage : ContentPage
{
	public EditContactPage()
	{
		InitializeComponent();
	}

    private void Btn_EditCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");  //we are writing like this because, by default the starting landing page mentioned in the app shell starts execution with "//". see microsoft docs.
    }
}