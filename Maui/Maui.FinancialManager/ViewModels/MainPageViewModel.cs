using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Maui.FinancialManager.Helpers;
using Maui.FinancialManager.Messages;

namespace Maui.FinancialManager.ViewModels;

public partial class MainPageViewModel : ObservableObject, IRecipient<AuthMessage>
{
    public MainPageViewModel()
    {
        this.InitializeApp();
        WeakReferenceMessenger.Default.Register<AuthMessage>(this);
    }

    void InitializeApp()
    {

    }

    public void Receive(AuthMessage message)
    {
    }

    [ObservableProperty]
    private View mainContent;
}

