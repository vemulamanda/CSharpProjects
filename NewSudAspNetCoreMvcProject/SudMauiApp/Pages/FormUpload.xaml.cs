using CommunityToolkit.Mvvm.ComponentModel;
using SudMauiApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SudMauiApp.Pages;

public partial class FormUpload : ContentPage
{
    public FD_ViewModel _ViewModel;
    
	public FormUpload()
	{
		InitializeComponent();

        var ProductService = new FarmApiService();
		_ViewModel = new FD_ViewModel(ProductService);

        Districts.ItemsSource = new List<string>
        {
            "Srikakulam", "Vizianagaram", "Visakhapatnam", "Anakapalli", "Alluri Sitharama Raju", "Parvathipuram Manyam",
            "East Godavari", "Kakinada", "Dr. B.R. Ambedkar Konaseema", "West Godavari", "Eluru", "Krishna", "NTR", "Guntur", "Palnadu", "Bapatla", "Prakasam", "Sri Potti Sriramulu Nellore",
            "Kurnool", "Nandyal", "Anantapuramu", "Sri Sathya Sai", "Chittoor", "Tirupati", "Annamayya", "YSR (Kadapa)", "Madanapalle",
            "Markapuram", "Polavaram"
        };

		BindingContext = _ViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        Districts.SelectedItem = null;
        Districts.SelectedItem = -1;

        await _ViewModel.LoadFishData();

        try
        {
            LoadingOverlay.IsVisible = true;

            var LoggedIn_User = await SecureStorage.GetAsync("user_identity");

            if (LoggedIn_User != null || LoggedIn_User != "")
            {
                var stored_jwttoken = await SecureStorage.GetAsync("jwt_token");

                FarmApiService apiService = new FarmApiService();
                string response = await apiService.UserLoginCheck();
                if (response == "Login Successful")
                {
                    Login_Iconbtn.IsVisible = false;
                    Logout_Iconbtn.IsVisible = true;
                    ScrollingLabel.TextColor = Colors.Green;
                    ScrollingLabel.Text = $"Hello {LoggedIn_User}. Welcome";
                }
                else
                {
                    Login_Iconbtn.IsVisible = true;
                    Logout_Iconbtn.IsVisible = false;
                    ScrollingLabel.TextColor = Colors.Red;
                    ScrollingLabel.Text = "Please login to Post AD";
                }
            }
        }
        catch (Exception ex)
        {
            Login_Iconbtn.IsVisible = true;
            Logout_Iconbtn.IsVisible = false;
            ScrollingLabel.TextColor = Colors.Red;
            ScrollingLabel.Text = "Please login to Post AD";
        }
        finally
        {
            LoadingOverlay.IsVisible = false;
        }
    }

    private async void Login_Iconbtn_Clicked(object sender, EventArgs e)
    {
        LoadingOverlay.IsVisible = true;

        //await Navigation.PushAsync(new LoginPage());
        await Shell.Current.Navigation.PushAsync(new LoginPage());

        LoadingOverlay.IsVisible = false;
    }

    private async void Btn_SpecificAd_Clicked(object sender, EventArgs e)
    {
        LoadingOverlay.IsVisible = true;

        if (sender is Button b)
        {
           FishData FD = b.CommandParameter as FishData;

            await Shell.Current.GoToAsync($"{nameof(SpecificAdPage)}?UserId={FD.custid}");
        }

        LoadingOverlay.IsVisible = false;
    }

    private async void Btn_PostAd_Clicked(object sender, EventArgs e)
    {
        try
        {
            LoadingOverlay.IsVisible = true;

            var stored_jwttoken = await SecureStorage.GetAsync("jwt_token");

            FarmApiService apiService = new FarmApiService();
            string response = await apiService.UserLoginCheck();
            if (response == "Login Successful")
            {
                //await Task.Delay(3000); // simulate API call
                await Navigation.PushAsync(new PostAdPage());
            }
            else
            {
                await DisplayAlert("INFO", response, "OK");
                await Navigation.PushAsync(new LoginPage());
            }
        }
        finally
        {
            LoadingOverlay.IsVisible = false;
        }
    }


    private async void Btn_EditAd_Clicked(object sender, EventArgs e)
    {
        try
        {
            LoadingOverlay.IsVisible = true;

            var stored_jwttoken = await SecureStorage.GetAsync("jwt_token");

            FarmApiService apiService = new FarmApiService();
            string response = await apiService.UserLoginCheck();
            if (response == "Login Successful")
            {
                await Task.Delay(3000); // simulate API call
                await Navigation.PushAsync(new EditAdPage(_ViewModel));
            }
            else
            {
                await DisplayAlert("INFO", response, "OK");
                await Navigation.PushAsync(new LoginPage());
            }
        }
        finally
        {
            LoadingOverlay.IsVisible = false;
        }
    }


    private async void Logout_Iconbtn_Clicked(object sender, EventArgs e)
    {
        LoadingOverlay.IsVisible = true;

        await Shell.Current.GoToAsync("LoginPage");

        //SecureStorage.Remove("jwt_token");
        //SecureStorage.Remove("user_identity");
        //SecureStorage.Remove("user_guid");

        //await Task.Delay(1000);

        //Login_Iconbtn.IsVisible = true;
        //Logout_Iconbtn.IsVisible = false;
        //ScrollingLabel.TextColor = Colors.Red;
        //ScrollingLabel.Text = "Please login to Post AD";

        LoadingOverlay.IsVisible = false;
    }


    private async void btn_DistrictSearch_Clicked(object sender, EventArgs e)
    {
        //await DisplayAlert("Info", Districts.SelectedItem.ToString(), "OK");

        string Selected_District = Districts.SelectedItem.ToString();

        if(Selected_District == null)
        {
            await DisplayAlert("Message", "Please select a district from dropdown", "Ok");
            return;
        }

        try
        {
            LoadingOverlay.IsVisible = true;

            await _ViewModel.LoadFishDataByDistrict(Selected_District);
        }
        finally
        {
            LoadingOverlay.IsVisible = false;
        }
    }
}