namespace SudMauiApp.Pages;

[QueryProperty(nameof(CustImages), "CustImages")]
public partial class DisplayCustImages : ContentPage
{
    private string _custImages;
    public string CustImages
    {
        get => _custImages;
        set
        {
            _custImages = value;

            // Convert back to array
            ImageList = value.Split(';').ToList();

            OnPropertyChanged(nameof(ImageList));
        }
    }

    public List<string> ImageList { get; set; }

    public DisplayCustImages()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void btn_GoBack_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
};