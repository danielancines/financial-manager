using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Maui.FinancialManager.Models;

namespace Maui.FinancialManager.ViewModels;

public partial class MedicineDetailsViewModel : ObservableObject, IQueryAttributable
{
	public MedicineDetailsViewModel()
	{
	}

    [ObservableProperty]
    Medicine medicine;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var medicine = query["medicine"] as Medicine;
        if (medicine == null)
            return;

        this.Medicine = medicine;
    }
}

