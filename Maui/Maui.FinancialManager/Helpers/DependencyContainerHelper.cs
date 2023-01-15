namespace Maui.FinancialManager.Helpers;

public static class DependencyContainerHelper
{
    public static TService GetService<TService>()
        => Current.GetService<TService>();

    public static IEnumerable<TService> GetServices<TService>()
    => Current.GetServices<TService>();

    static IServiceProvider Current =>
#if WINDOWS10_0_17763_0_OR_GREATER
			MauiWinUIApplication.Current.Services;
#elif ANDROID
            MauiApplication.Current.Services;
#elif IOS || MACCATALYST
			MauiUIApplicationDelegate.Current.Services;
#else
			null;
#endif
}

