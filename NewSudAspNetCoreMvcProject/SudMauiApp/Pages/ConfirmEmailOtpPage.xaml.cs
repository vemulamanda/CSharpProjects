using Microsoft.Maui.Controls.Shapes;
using System.Net.Mail;
using System.Threading.Tasks;
using SudMauiApp.Models;

namespace SudMauiApp.Pages;

[QueryProperty(nameof(UserId), "userId")]
public partial class ConfirmEmailOtpPage : ContentPage
{
	public string UserId { get; set; }

	public ConfirmEmailOtpPage()
	{
		InitializeComponent();

        if (UserId == null || UserId == "")
        {
            var User_Id = Preferences.Get("UserId", string.Empty);
            UserId = User_Id;
        }
                
        BindingContext = this;
	}

    private async void btn_OTPSubmit_Clicked(object sender, EventArgs e)
    {
		if(user_otp.Text == null || user_otp.Text == "")
		{
            await DisplayAlert("Error", "Please enter OTP sent to your Email", "Ok");
        }
		else
		{
            var model = new MultipartFormDataContent();

            model.Add(new StringContent(user_otp.Text ?? ""), "SubmittedToken");
            model.Add(new StringContent(UserId ?? ""), "userId");

            try
            {
                LoadingOverlay.IsVisible = true;

                var _apiservice = new FarmApiService();
                var responseMessage = await _apiservice.ConfirmEmail(model);

                await DisplayAlert("Info", responseMessage.ToString(), "OK");

                await Shell.Current.GoToAsync("//FormUpload");
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