using MauiMvvmProject.Models.ViewModels;

namespace MauiMvvmProject.Pages;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();
	}

    private void Btn_emp01_Clicked(object sender, EventArgs e)
    {
        var employee01 = new EmployeeDetailViewModel2
        {
            EmployeeId = "1001",
            EmployeeName = "Sudheer",
            Email = "sudheer@gmail.com",
            IsPartTimer = true
        };
        var empdetailspage = new EmployeeDetailPage();
        empdetailspage.BindingContext = employee01;
        Navigation.PushAsync(empdetailspage);
    }

    private void Btn_emp02_Clicked(object sender, EventArgs e)
    {
        var employee01 = new EmployeeDetailViewModel2
        {
            EmployeeId = "1002",
            EmployeeName = "Eswar",
            Email = "eswar@gmail.com",
            IsPartTimer = true
        };
        var empdetailspage = new EmployeeDetailPage();
        empdetailspage.BindingContext = employee01;
        Navigation.PushAsync(empdetailspage);
    }

    private void Btn_emp03_Clicked(object sender, EventArgs e)
    {
        var employee01 = new EmployeeDetailViewModel2
        {
            EmployeeId = "1003",
            EmployeeName = "Mahesh",
            Email = "mahesh@gmail.com",
            IsPartTimer = false
        };
        var empdetailspage = new EmployeeDetailPage();
        empdetailspage.BindingContext = employee01;
        Navigation.PushAsync(empdetailspage);
    }
}