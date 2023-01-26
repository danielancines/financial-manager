using Maui.FinancialManager.Searchers;
using Maui.FinancialManager.Searchers.Base;
using Maui.FinancialManager.ViewModels;
using Maui.FinancialManager.Views;
using Maui.FinancialManager.Serializers;
using Plugin.Fingerprint.Abstractions;

namespace Maui.FinancialManager.Configuration;

public static class BuildConfiguration
{
    public static MauiAppBuilder ConfigureApp(this MauiAppBuilder builder)
    {
        ConfigureViewModels(builder);
        ConfigureViews(builder);
        ConfigureSearchers(builder);
        ConfigureSerializers(builder);
        ConfigureSecurity(builder);

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
        builder.Services.AddTransient<MedicineDetailsView>();
        builder.Services.AddTransient<ProductsPricesView>();
    }

    static void ConfigureViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<MedicinePricesViewModel>();
        builder.Services.AddTransient<AccountViewModel>();
        builder.Services.AddTransient<MedicineDetailsViewModel>();
    }

    static void ConfigureSerializers(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<DrogaraiaSerializer>();
        builder.Services.AddTransient<PanvelSerializer>();
        builder.Services.AddTransient<SaoJoaoSerializer>();
    }

    static void ConfigureSecurity(MauiAppBuilder builder)
    {
        
    }
}

