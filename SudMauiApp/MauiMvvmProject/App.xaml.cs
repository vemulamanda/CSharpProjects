using MauiMvvmProject.Pages;

namespace MauiMvvmProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navigationpage = new NavigationPage(new EmployeeListPage());
            MainPage = navigationpage;
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}