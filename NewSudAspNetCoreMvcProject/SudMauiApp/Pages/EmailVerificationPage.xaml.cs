using System.Threading.Tasks;
using SudMauiApp.Models;

namespace SudMauiApp.Pages;

public partial class EmailVerificationPage : ContentPage
{
	public EmailVerificationPage()
	{
		InitializeComponent();
	}

    private async void btn_EmailSubmit_Clicked(object sender, EventArgs e)
    {
        //await DisplayAlert("info", user_email.Text, "Ok");

        if (user_email.Text == null || user_email.Text == "")
        {
            await DisplayAlert("Error", "Please enter your registered Email Address", "Ok");
        }
        else
        {
            var model = new MultipartFormDataContent();

            model.Add(new StringContent(user_email.Text ?? ""), "email");

            try
            {
                LoadingOverlay.IsVisible = true;

                var _apiservice = new FarmApiService();
                var responseMessage = await _apiservice.VerifyEmailAddress(model);

                if (responseMessage is RegistrationResponse res)
                {
                    await DisplayAlert("Info", res.userid, "OK");
                    Preferences.Set("UserId", res.userid);
                    await Shell.Current.GoToAsync($"ConfirmEmailOtpPage?userId={res.userid}");
                }
                else
                {
                    await DisplayAlert("ERROR", responseMessage.ToString(), "Ok");
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
}