using CommunityToolkit.Mvvm.ComponentModel;
using SudMauiApp.Models;
using System.Collections.ObjectModel;

namespace SudMauiApp.Pages;

public partial class EditAdPage : ContentPage
{
    public readonly FD_ViewModel fd_vm;
    //public ObservableCollection<FishData> userSpecificAds { get; set; }

    public EditAdPage(FD_ViewModel fd_vm)
	{
		InitializeComponent();
        this.fd_vm = fd_vm;

        //EditClicked_Clicked();
        // Initialize the collection so it's not null
        //userSpecificAds = new ObservableCollection<FishData>();

        BindingContext = fd_vm;
    }

    //Simple explanation:

    //FormUplaod page passes: await Navigation.PushAsync(new EditAdPage(_ViewModel));
    //EditAdPage receives in the constructor: public EditAdPage(FD_ViewModel fd_vm)
    //Now the data passed from form upload page will be accessed only in constructor,
    //so to make it available all over the page we create a field fd_vm and assign the constructor fd_vm to this newly created field(fd_vm).
    //Now all data is accessible on newly created fd_vm field all over the page.

    // How this page works:
    //
    // 1. The FormUpload page navigates to EditAdPage and passes the existing FD_ViewModel instance.
    //    Because we pass the same ViewModel, all previously loaded data (Finalfishdata) is available.
    //
    // 2. In the constructor, we store the ViewModel (this.fd_vm = fd_vm) and set BindingContext = fd_vm.
    //    This allows the XAML UI to access all ViewModel properties, including UserSpecificAds.
    //
    // 3. When the page first appears, OnAppearing() is triggered automatically by MAUI.
    //    At this moment, the UI is already created, but UserSpecificAds is still empty.
    //
    // 4. OnAppearing() calls fd_vm.LoadUserAdsAsync(), which filters Finalfishdata by userGuid
    //    and fills UserSpecificAds with only the ads belonging to the logged‑in user.
    //
    // 5. Because UserSpecificAds is an ObservableCollection and the XAML binds to it,
    //    the UI updates automatically as soon as items are added.
    //
    // Summary:
    // - BindingContext = fd_vm gives XAML access to the ViewModel.
    // - OnAppearing() loads the user’s ads at the correct time.
    // - ObservableCollection ensures the UI refreshes automatically.



    protected override async void OnAppearing()
    {
        base.OnAppearing();

        fd_vm.UserSpecificAds.Clear();

        //EditClicked_Clicked();
        await fd_vm.LoadUserAdsAsync();
    }

   /* private async void EditClicked_Clicked()
    {
        string id = await SecureStorage.GetAsync("user_guid");

        //string responseMessage = await service.GetSingleFishData(id);
        var responseMessage = fd_vm.finalfishdata.Where(ad => ad.userGuid == id).ToList();

        foreach (var ad in responseMessage)
        {
            //await DisplayAlert("Ad", ad.address, "Ok");
            fd_vm.UserSpecificAds.Add(ad);
        }
    }
   */
    private async void Btn_SpecificAd_Edit_Clicked(object sender, EventArgs e)
    {
        LoadingOverlay.IsVisible = true;

        if (sender is Button b)
        {
            FishData FD = b.CommandParameter as FishData;

            await Shell.Current.GoToAsync($"PostAdPage", new Dictionary<string, object>
            {
                {"EditSingleFD", FD},
            });
        }

        LoadingOverlay.IsVisible = false;
    }

    private async void Btn_SpecificAd_Delete_Clicked(object sender, EventArgs e)
    {
        LoadingOverlay.IsVisible = true;

        if (sender is Button b)
        {
            FishData FD = b.CommandParameter as FishData;

            await Shell.Current.GoToAsync($"PostAdPage", new Dictionary<string, object>
            {
                {"DeleteSingleFD", FD},
            });
        }

        LoadingOverlay.IsVisible = false;
    }
}