using Maui.FinancialManager.Searchers;
using Maui.FinancialManager.Searchers.Base;
using Maui.FinancialManager.ViewModels;
using Maui.FinancialManager.Views;

namespace Maui.FinancialManager.Configuration;

public static class BuildConfiguration
{
    public static MauiAppBuilder ConfigureApp(this MauiAppBuilder builder)
    {
        ConfigureViewModels(builder);
        ConfigureViews(builder);
        ConfigureSearchers(builder);

        return builder;
    }

    static void ConfigureSearchers(MauiAppBuilder builder)
    {
        builder.Services.AddTransient<IMedicineSearcher, SaoJoaoSearcher>();
        builder.Services.AddTransient<IMedicineSearcher, DrogaRaiaSearcher>();
        builder.Services.AddTransient<IMedicineSearcher, PanvelSearcher>();
    }

    static void ConfigureViews(MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<AccountView>();
        builder.Services.AddTransient<MedicinePricesView>();
    }

    static void ConfigureViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<MedicinePricesViewModel>();
        builder.Services.AddTransient<AccountViewModel>();
    }
}

