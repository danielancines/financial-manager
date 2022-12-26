using Maui.FinancialManager.ViewModels;

namespace Maui.FinancialManager.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

}

