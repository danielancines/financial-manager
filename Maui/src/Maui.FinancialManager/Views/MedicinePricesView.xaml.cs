using Maui.FinancialManager.ViewModels;

namespace Maui.FinancialManager.Views;

public partial class MedicinePricesView : ContentPage
{
	public MedicinePricesView(MedicinePricesViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
    }
}
