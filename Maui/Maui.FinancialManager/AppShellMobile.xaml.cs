using Maui.FinancialManager.Views;

namespace Maui.FinancialManager;

public partial class AppShellMobile : Shell
{
    public AppShellMobile()
    {
        InitializeComponent();
        InitializeRoutes();

        Application.Current.UserAppTheme = AppTheme.Dark;
    }

    void InitializeRoutes()
    {
        Routing.RegisterRoute("login", typeof(LoginView));
        Routing.RegisterRoute("medicinesearch/medicinedetail", typeof(MedicineDetailsView));
    }
}
