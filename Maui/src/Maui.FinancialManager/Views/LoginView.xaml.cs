using Maui.FinancialManager.ViewModels;

namespace Maui.FinancialManager.Views;

public partial class LoginView : ContentView
{
	public LoginView(LoginViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}
