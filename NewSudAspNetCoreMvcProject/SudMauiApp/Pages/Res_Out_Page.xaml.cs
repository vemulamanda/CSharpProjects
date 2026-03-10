using System.Threading.Tasks;
using SudMauiApp.Models;
using SudMauiApp.Pages;

namespace SudMauiApp.Pages;

public partial class Res_Out_Page : ContentPage
{
	public string msg { get; set; }
	public Res_Out_Page(string _msg)
	{
		InitializeComponent();
		this.msg = _msg;
		BindingContext = this;
    }

    private async void Btn_close_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("//FormUpload");
    }
}