using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Maui.FinancialManager.Core.Collections;
using Maui.FinancialManager.Core.Collections.Specialized;
using Maui.FinancialManager.Helpers;
using Maui.FinancialManager.Messages;
using Maui.FinancialManager.Models;
using Maui.FinancialManager.Searchers.Base;
using Maui.FinancialManager.Views.Mobile;

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
        this.MainContent = DependencyContainerHelper.GetService<Views.LoginView>();
    }

    public void Receive(AuthMessage message)
    {
        if (message.IsAuthenticated)
            this.MainContent = DependencyContainerHelper.GetService<HomeMobile>();
        else
            this.MainContent = DependencyContainerHelper.GetService<Views.LoginView>();

    }

    [ObservableProperty]
    private View mainContent;
}

