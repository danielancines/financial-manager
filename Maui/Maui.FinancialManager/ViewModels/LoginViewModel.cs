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

    public string Version { get; set; } = $"{AppInfo.Current.Name} - {AppInfo.Version}";

    [ObservableProperty]
    string userLogin;

    [ObservableProperty]
    string userPassword;

    [RelayCommand]
    async void Login()
    {

        //_ = Shell.Current.GoToAsync("//Home/MedicineSearch");
        //return;

        var client = new HttpClient();

        var data = new
        {
            login = this.UserLogin,
            password = this.UserPassword

        };

        var body = new StringContent(JsonConvert.SerializeObject(data),
                                  Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync("http://api.danielancines.com/api/v1/auth", body);
            if (response.IsSuccessStatusCode)
            {
                Preferences.Set(nameof(this.UserLogin), this.UserLogin);
                _ = Shell.Current.GoToAsync("//medicinesearch");
            }
            else
            {
                _ = Shell.Current.DisplayAlert("Erro", "Usuário e/ou senha inválidos", "Ok");
            }

        }
        catch (Exception ex)
        {
            //TODO Log errors with authentication and send it before to server
        }
    }

    void Initialize()
    {
        if (Preferences.ContainsKey(nameof(this.UserLogin)))
            this.UserLogin = Preferences.Get(nameof(this.UserLogin), string.Empty);
    }
}

