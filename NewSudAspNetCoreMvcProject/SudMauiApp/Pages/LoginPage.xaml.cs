using SudMauiApp.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SudMauiApp.Pages;

public partial class LoginPage : ContentPage
{
    public FD_ViewModel _ViewModel;

    public LoginPage()
	{
		InitializeComponent();

        var ProductService = new FarmApiService();
        _ViewModel = new FD_ViewModel(ProductService);

        BindingContext = _ViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var apiservice = new FarmApiService();
        var responseMessage = await apiservice.UserLoginCheck();

        if (responseMessage.Contains("Login Successful"))
        {
            btn_LoginLogoff.Text = "Logout";
        }
    }

    private async void btn_Register_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrationPage());
    }

    private async void btn_ForgotPassword_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ForgotPasswordPage());
    }

    private async void Btn_Submit_Clicked(object sender, EventArgs e)
    {
        if(btn_LoginLogoff.Text == "Logout")
        {
            SecureStorage.Remove("jwt_token");
            SecureStorage.Remove("user_identity");
            SecureStorage.Remove("user_guid");

            await DisplayAlert("SUCCESS", "Logged Out Successfully.", "OK");

            btn_LoginLogoff.Text = "Login";

            return;
        }

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

        var model = new MultipartFormDataContent();

        model.Add(new StringContent(username.Text ?? ""), "Username");
        model.Add(new StringContent(password.Text ?? ""), "Password");
        model.Add(new StringContent("false"), "RememberMe");

        try
        {
            LoadingOverlay.IsVisible = true;

            var apiservice = new FarmApiService();
            var responseMessage = await apiservice.UserLogin(model);

            await DisplayAlert("Message", $"Hi {responseMessage.identity}. Login Successful.", "OK");
            await Shell.Current.GoToAsync("//FormUpload");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            if(ex.Message.Contains("Email registration"))
            {
                await Shell.Current.GoToAsync("EmailVerificationPage");
            }
        }
        finally
        {
            LoadingOverlay.IsVisible = false;
        }
    }

    private async void btn_DeleteAccount_Clicked(object sender, EventArgs e)
    {
        var apiservice = new FarmApiService();
        var responseMessage = await apiservice.UserLoginCheck();

        if(responseMessage.Contains("Login Successful"))
        {
            string userguid = await SecureStorage.GetAsync("user_guid");

            if (userguid == null || userguid == string.Empty)
            {
                await DisplayAlert("ERROR", "User Not Found. Please logout and login again..", "Ok");
            }
            else
            {
               string UserAdsCheck = await apiservice.GetAdsByUserGuid(userguid);
                if (UserAdsCheck != "0")
                {
                    await DisplayAlert("Message", $"Your Ads = {UserAdsCheck.ToString()}. \n\nPlease delete your AD's to delete your account.", "OK");

                    await _ViewModel.LoadFishData();
                    await Navigation.PushAsync(new EditAdPage(_ViewModel));

                }
                else
                {
                    bool userprompt = await DisplayAlert("Warning", "Do you want to delete your account ?", "yes", "no");
                    if(userprompt)
                    {
                        var UserAccountDeletion = await apiservice.DeleteUserAccount(userguid);

                        if (UserAccountDeletion is ErrorResponse err)
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
                            await DisplayAlert("Info", "Account removed successfully. Thank you for using our service.", "Ok");

                            SecureStorage.Remove("jwt_token");
                            SecureStorage.Remove("user_identity");
                            SecureStorage.Remove("user_guid");

                            btn_LoginLogoff.Text = "Logout";

                            await Shell.Current.GoToAsync("//FormUpload");
                        }
                    }
                    else
                        return;
                    }
                }
            }
        else
        {
            await DisplayAlert("Message", responseMessage, "OK");
        }
    }
}
