using CommunityToolkit.Mvvm.ComponentModel;
using SudMauiApp.Models;
using System;
using System.Threading.Tasks;

namespace SudMauiApp.Pages;

[QueryProperty(nameof(UserId), "UserId")]
public partial class SpecificAdPage : ContentPage
{
    private readonly FD_ViewModel _viewmodel;

    public int UserId { get; set; }

    public SpecificAdPage()
    {
        InitializeComponent();
        _viewmodel = new FD_ViewModel(new FarmApiService());
        BindingContext = _viewmodel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewmodel.LoadSingleFishData(UserId);
        //Console.WriteLine($"API returned: {_viewmodel.SingleAd?.name}");
    }


    private async void btn_FullImgShow_Clicked(object sender, EventArgs e)
    {
        string imgpaths = string.Join(";", _viewmodel.SingleAd.imagePath);

        await Shell.Current.GoToAsync($"{nameof(DisplayCustImages)}?CustImages={imgpaths}");
    }

    private async void btn_GoBack_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
};

