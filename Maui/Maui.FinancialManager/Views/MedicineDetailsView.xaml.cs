using Maui.FinancialManager.ViewModels;

namespace Maui.FinancialManager.Views;

public partial class MedicineDetailsView : ContentPage
{
	public MedicineDetailsView(MedicineDetailsViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}
