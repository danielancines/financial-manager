using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Maui.FinancialManager.ViewModels;

public partial class AccountViewModel : ObservableObject
{
    public AccountViewModel()
    {
        this.useBiometric = Preferences.Get(USE_BIOMETRIC, false);
    }

    const string USE_BIOMETRIC = "useBiometric";
    [RelayCommand]
    void Logout()
    {
        _ = Shell.Current.GoToAsync("//Login");
    }

    [ObservableProperty]
    bool useBiometric;
    partial void OnUseBiometricChanged(bool value)
    {
        Preferences.Set(USE_BIOMETRIC, value);
    }
}

