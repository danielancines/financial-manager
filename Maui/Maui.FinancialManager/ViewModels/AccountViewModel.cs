using System;
using CommunityToolkit.Mvvm.Input;

namespace Maui.FinancialManager.ViewModels;

public partial class AccountViewModel
{
    [RelayCommand]
    void Logout()
    {
        _ = Shell.Current.GoToAsync("//Login");
    }
}

