using Maui.FinancialManager.Views;
using Maui.FinancialManager.Views.Mobile;

namespace Maui.FinancialManager;

public partial class AppShellMobile : Shell
{
	public AppShellMobile()
	{
		InitializeComponent();
		InitializeRoutes();
	}

    void InitializeRoutes()
    {
		Routing.RegisterRoute("login", typeof(LoginPage));
        Routing.RegisterRoute("home", typeof(HomeMobilePage));
    }
}
