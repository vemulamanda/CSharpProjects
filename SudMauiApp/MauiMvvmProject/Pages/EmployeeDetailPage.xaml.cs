using MauiMvvmProject.Models.ViewModels;

namespace MauiMvvmProject.Pages;

public partial class EmployeeDetailPage : ContentPage
{
	public EmployeeDetailPage()
	{
		InitializeComponent();

		var employeeDetailViewModel = new EmployeeDetailViewModel
		{
			EmployeeId = "1001",
			EmployeeName = "Sudheer",
			Email = "sudheerkumar.v3@gmail.com",
			IsPartTime = true
		};
		BindingContext = employeeDetailViewModel;
	}
}