using Maui.FinancialManager.Views;

namespace Maui.FinancialManager;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        AppShell.InitializeRouting();
    }

    private static void InitializeRouting()
    {
        Routing.RegisterRoute("medicinesearch/medicinedetail", typeof(MedicineDetailsView));
    }
}
