﻿using Maui.FinancialManager.ViewModels;

namespace Maui.FinancialManager.Views;

public partial class MedicinePricesPage : ContentPage
{
	public MedicinePricesPage(MedicinePricesPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
    }
}
