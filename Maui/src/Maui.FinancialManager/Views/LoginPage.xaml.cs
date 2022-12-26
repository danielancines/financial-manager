using Maui.FinancialManager.ViewModels;

namespace Maui.FinancialManager.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}
