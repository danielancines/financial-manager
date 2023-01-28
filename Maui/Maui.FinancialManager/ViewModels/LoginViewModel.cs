using System.Diagnostics;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

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
    bool hasBiometricAuthentication;

    [ObservableProperty]
    string userPassword;

    [RelayCommand]
    async void Login()
    {
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
                Preferences.Set(nameof(this.UserPassword), this.UserPassword);
                this.UserPassword = null;
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

    [RelayCommand]
    async void LoginByFaceId()
    {
        var dialogConfig = new AuthenticationRequestConfiguration("My App", "Authenticate by faceid")
        {
            CancelTitle = "Cancelar",
            FallbackTitle = "Voltar",
            AllowAlternativeAuthentication = true,
            ConfirmationRequired = true
        };

        var authResult = await CrossFingerprint.Current.AuthenticateAsync(dialogConfig);
        if (authResult.Authenticated)
        {
            this.UserPassword = Preferences.Get(nameof(this.UserPassword), string.Empty);
            this.LoginCommand.Execute(null);
        }
    }

    async void Initialize()
    {
        if (Preferences.ContainsKey(nameof(this.UserLogin)))
            this.UserLogin = Preferences.Get(nameof(this.UserLogin), string.Empty);

        var hasBiometric = await CrossFingerprint.Current.GetAvailabilityAsync();
        this.HasBiometricAuthentication = hasBiometric == FingerprintAvailability.Available;

        if (this.HasBiometricAuthentication && !string.IsNullOrEmpty(this.UserLogin))
            this.LoginByFaceIdCommand.Execute(null);
    }
}

