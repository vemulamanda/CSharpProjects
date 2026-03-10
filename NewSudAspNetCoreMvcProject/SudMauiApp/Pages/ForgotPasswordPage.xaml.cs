using SudMauiApp.Models;

namespace SudMauiApp.Pages;

public partial class ForgotPasswordPage : ContentPage
{
	public ForgotPasswordPage()
	{
		InitializeComponent();

		emailentry.Focus();
	}

    private async void btn_ResetPassword_Clicked(object sender, EventArgs e)
    {
        if (emailentry.Text == null || emailentry.Text == "")
        {
            await DisplayAlert("Error", "Please enter email address", "OK");
            emailentry.Focus();
            return;
        }

        var model = new MultipartFormDataContent();

        model.Add(new StringContent(emailentry.Text ?? ""), "Email");

        try
        {
            LoadingOverlay.IsVisible = true;

            var _apiservice = new FarmApiService();
            var responseMessage = await _apiservice.ForgotPassword(model);

            //await DisplayAlert("INFO", responseMessage.ToString(), "Ok");

            if (responseMessage is RegistrationResponse res)
            {
                await DisplayAlert("INFO", "OTP Sent Successfully", "OK");
                Preferences.Set("UserId", res.userid);
                await Shell.Current.GoToAsync("ConfirmPasswordOtpPage");//?userId={res.userid}");
            }
            else if(responseMessage is ErrorResponse validation)
            {
                string allErrors = "";

                foreach (var field in validation.errors)
                {
                    foreach (var message in field.Value)
                    {
                        allErrors += $"{message}\n\n";
                    }
                }
                await DisplayAlert("ERROR", allErrors, "OK");
            }
            else if (responseMessage is ErrorResponse error)
            {
                await DisplayAlert("ERROR", error.error_msg, "OK");
            }
            else
            {
                await DisplayAlert("ERROR", responseMessage.ToString(), "OK");
                if(responseMessage.ToString().Contains("Email is not verified"))
                {
                    bool answer = await DisplayAlert("Question", "Do you want to verify you email Address first?", "yes", "no");
                    if(answer)
                    {
                        await Shell.Current.GoToAsync("EmailVerificationPage");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            LoadingOverlay.IsVisible = false;
        }
    }
}