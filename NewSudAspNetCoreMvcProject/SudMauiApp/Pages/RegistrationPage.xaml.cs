using SudMauiApp.Models;
using System.Text.Json;

namespace SudMauiApp.Pages;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}

    private async void btn_RegistrationSubmit_Clicked(object sender, EventArgs e)
    {
        if (username.Text == null || username.Text == "")
        {
            await DisplayAlert("Error", "Please enter username", "OK");
            username.Focus();
            return;
        }
        if (password.Text == null || password.Text == "")
        {
            await DisplayAlert("Error", "Please enter password", "OK");
            password.Focus();
            return;
        }
        if (confirm_password.Text == null || confirm_password.Text == "")
        {
            await DisplayAlert("Error", "Please enter confirm password", "OK");
            confirm_password.Focus();
            return;
        }
        if (email_address.Text == null || email_address.Text == "")
        {
            await DisplayAlert("Error", "Please enter email address", "OK");
            email_address.Focus();
            return;
        }
        if (mobile_number.Text == null || mobile_number.Text == "")
        {
            await DisplayAlert("Error", "Please enter mobile number", "OK");
            mobile_number.Focus();
            return;
        }

        var model = new MultipartFormDataContent();

        model.Add(new StringContent(username.Text ?? ""), "Username");
        model.Add(new StringContent(password.Text ?? ""), "Password");
        model.Add(new StringContent(confirm_password.Text), "ConfirmPassword");
        model.Add(new StringContent(email_address.Text), "Email");
        model.Add(new StringContent(mobile_number.Text), "Mobile");

        try
        {
            LoadingOverlay.IsVisible = true;

            var _apiservice = new FarmApiService();
            var responseMessage = await _apiservice.Registration(model);

            if (responseMessage is RegistrationResponse res)
            {
                await DisplayAlert("INFO", "OTP Sent Successfully.", "OK");
                Preferences.Set("UserId", res.userid);
                await Shell.Current.GoToAsync($"ConfirmEmailOtpPage?userId={res.userid}");
            }
            else if (responseMessage is ErrorResponse validation)
            { 
                string allErrors = "";

                foreach (var field in validation.errors)
                {
                    foreach (var message in field.Value)
                    {
                        allErrors += $"{message}\n\n";
                    }
                }
                await DisplayAlert("Invalid Details", allErrors, "OK");
            }
            else if (responseMessage is ErrorResponse error)
            {
                await DisplayAlert("Invalid Details", error.error_msg, "OK");
            }
            else
            {
                await DisplayAlert("Invalid Details", responseMessage.ToString(), "OK");
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