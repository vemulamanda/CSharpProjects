namespace SudMauiApp.Pages;
using SudMauiApp.Models;

//[QueryProperty(nameof(UserId), "userId")]
public partial class ConfirmPasswordOtpPage : ContentPage
{    public string UserId { get; set; }
    public ConfirmPasswordOtpPage()
	{
		InitializeComponent();

        //if (UserId == null || UserId == "")
        //{
            //var User_Id = Preferences.Get("UserId", string.Empty);
            //UserId = User_Id;
        //}

        BindingContext = this;
    }

    private async void btn_OTPSubmit_Clicked(object sender, EventArgs e)
    {
        if (user_otp.Text == null || user_otp.Text == "")
        {
            await DisplayAlert("Error", "Please enter OTP sent to your Email", "Ok");
        }
        else
        {
            Preferences.Set("SubmittedToken", user_otp.Text);
            await Shell.Current.GoToAsync("PasswordResetPage");
        }
    }
}