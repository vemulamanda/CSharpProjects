using SudMauiApp.Models;
using SudMauiApp.Pages;

namespace SudMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Routing.RegisterRoute(nameof(FormUpload), typeof(FormUpload));
            Routing.RegisterRoute(nameof(SpecificAdPage), typeof(SpecificAdPage));
            Routing.RegisterRoute(nameof(DisplayCustImages), typeof(DisplayCustImages));
            Routing.RegisterRoute(nameof(PostAdPage), typeof(PostAdPage));
            Routing.RegisterRoute(nameof(ConfirmEmailOtpPage), typeof(ConfirmEmailOtpPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(EmailVerificationPage), typeof(EmailVerificationPage));
            Routing.RegisterRoute(nameof(PasswordResetPage), typeof(PasswordResetPage));
            Routing.RegisterRoute(nameof(ConfirmPasswordOtpPage), typeof(ConfirmPasswordOtpPage));
            Routing.RegisterRoute(nameof(EditAdPage), typeof(EditAdPage));
        }
    }
}
