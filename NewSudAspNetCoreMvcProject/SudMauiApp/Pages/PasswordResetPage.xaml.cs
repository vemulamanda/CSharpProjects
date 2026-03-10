using System.Threading.Tasks;
using SudMauiApp.Models;

namespace SudMauiApp.Pages;

public partial class PasswordResetPage : ContentPage
{
	public PasswordResetPage()
	{
		InitializeComponent();
	}

    private async void btn_PasswordResetSubmit_Clicked(object sender, EventArgs e)
    {
        var UserId = Preferences.Get("UserId", string.Empty);
        var user_otp = Preferences.Get("SubmittedToken", string.Empty);

        if (UserId == null || UserId == "")
        {
            await DisplayAlert("ERROR", "User ID not found. Please Re-enter your email again", "Ok");
            await Shell.Current.GoToAsync("ForgotPasswordPage");
        }
        else if(user_otp == null || user_otp == "")
        {
            await DisplayAlert("ERROR", "OTP not received. Please Re-enter your OTP again", "Ok");
            await Shell.Current.GoToAsync("ConfirmPasswordOtpPage");
        }
        else if(newPassword.Text == null || newPassword.Text == "" || confirmNewPassword.Text == null || confirmNewPassword.Text == "" || newPassword.Text != confirmNewPassword.Text)
        {
            await DisplayAlert("ERROR", "Either password fields are empty OR Password didn't match.", "Ok");
        }
        else
        {
            var model = new MultipartFormDataContent();

            model.Add(new StringContent(user_otp ?? ""), "SubmittedToken");
            model.Add(new StringContent(UserId ?? ""), "userId");
            model.Add(new StringContent(newPassword.Text ?? ""), "Password");
            model.Add(new StringContent(confirmNewPassword.Text ?? ""), "ConfirmPassword");

            try
            {
                LoadingOverlay.IsVisible = true;

                var _apiservice = new FarmApiService();
                var responseMessage = await _apiservice.ResetPassword(model);

                if (responseMessage is ErrorResponse err)
                {
                    // Case 1: ModelState-style errors
                    if (err.errors != null)
                    {
                        string allErrors = "";

                        foreach (var field in err.errors)
                        {
                            foreach (var message in field.Value)
                            {
                                allErrors += $"{message}\n\n";
                            }
                        }

                        await DisplayAlert("ERROR", allErrors, "OK");
                    }
                    // Case 2: Simple error message
                    else if (err.error_msg != null)
                    {                                  
                        await DisplayAlert("ERROR", err.error_msg.Trim(), "OK");
                    }
                    else
                    {
                        await DisplayAlert("ERROR", "Unknown Error Occured", "OK");
                    }
                }
                else
                {
                    // Success (string)
                    await DisplayAlert("SUCCESS", responseMessage.ToString(), "OK");
                    await Shell.Current.GoToAsync("LoginPage");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");

                await Shell.Current.GoToAsync("LoginPage");
            }
            finally
            {
                LoadingOverlay.IsVisible = false;
            }
        }
    }
}