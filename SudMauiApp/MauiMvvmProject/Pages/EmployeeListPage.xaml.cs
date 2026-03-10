using MauiMvvmProject.Models.ViewModels;

namespace MauiMvvmProject.Pages;

public partial class EmployeeListPage : ContentPage
{
	public EmployeeListPage()
	{
		InitializeComponent();
		BindingContext = new EmployeeViewModel();
	}
}