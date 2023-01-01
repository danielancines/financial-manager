using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Maui.FinancialManager.Messages;
using Newtonsoft.Json;

namespace Maui.FinancialManager.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    public LoginViewModel()
    {
        this.Initialize();
    }

    [ObservableProperty]
    string userLogin;

    [ObservableProperty]
    string userPassword;

    [RelayCommand]
    async void Login()
    {
        var client = new HttpClient(new NSUrlSessionHandler());

        var data = new
        {
            login = this.UserLogin,
            password = this.UserPassword

        };

        var body = new StringContent(JsonConvert.SerializeObject(data),
                                  Encoding.UTF8, "application/json");

        var response = await client.PostAsync("http://localhost:5095/api/v1/auth", body);
        if (response.IsSuccessStatusCode)
        {
            Preferences.Set(nameof(this.UserLogin), this.UserLogin);
            Preferences.Set(nameof(this.UserPassword), this.UserPassword);
            _ = Shell.Current.GoToAsync("//Home/MedicineSearch");
        } else
        {
            _= Shell.Current.DisplayAlert("Erro", "Usuário e/ou senha inválidos", "Ok");
        }
    }

    void Initialize()
    {
        if (Preferences.ContainsKey(nameof(this.UserLogin)))
            this.UserLogin = Preferences.Get(nameof(this.UserLogin), string.Empty);
    }
}

