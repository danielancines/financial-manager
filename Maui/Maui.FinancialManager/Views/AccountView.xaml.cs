using Maui.FinancialManager.ViewModels;

namespace Maui.FinancialManager.Views;

public partial class AccountView : ContentPage
{
	public AccountView(AccountViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}
