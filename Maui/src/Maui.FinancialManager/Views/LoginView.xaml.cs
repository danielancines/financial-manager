using Maui.FinancialManager.ViewModels;

namespace Maui.FinancialManager.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}
