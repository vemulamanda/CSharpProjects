using CodingDropletsMauiApp.Pages;
using CodingDropletsMauiApp.Pages.FlyoutPageDemo;
using CodingDropletsMauiApp.Pages.NavPageDemo;
using CodingDropletsMauiApp.Pages.TabbedPageDemo;

namespace CodingDropletsMauiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //var navigationPage = new NavigationPage(new NavContentPage1());
            //navigationPage.BarBackgroundColor = Colors.Red;
            //navigationPage.BarTextColor = Colors.GreenYellow;
            //MainPage = navigationPage;

            //MainPage = new DemoFlyoutPage01();

            MainPage = new StackLayoutDemo();
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}