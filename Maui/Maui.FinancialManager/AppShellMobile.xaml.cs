using Maui.FinancialManager.Views;

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
		Routing.RegisterRoute("login", typeof(LoginView));
    }
}
