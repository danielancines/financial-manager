using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Maui.FinancialManager.Messages;

namespace Maui.FinancialManager.ViewModels;

public partial class LoginViewModel
{
    public LoginViewModel()
    {
        
    }
    [RelayCommand]
    void Login()
    {
        Shell.Current.GoToAsync("//MedicinePrices");
        
    }
}

