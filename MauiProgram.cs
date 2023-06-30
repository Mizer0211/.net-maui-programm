using SQLiteDemo.Services;
using SQLiteDemo.ViewModels;
using SQLiteDemo.Views;

namespace SQLiteDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services
        builder.Services.AddSingleton<IPlanetService, PlanetService>();


        //Views Registration
        builder.Services.AddSingleton<PlanetListPage>();
        //builder.Services.AddTransient<PlanetListPage>();
        builder.Services.AddTransient<AddUpdatePlanetDetail>();


        //View Modles 
        builder.Services.AddSingleton<PlanetListPageViewModel>();
        //builder.Services.AddTransient<PlanetListPageViewModel>();
        builder.Services.AddTransient<AddUpdatePlanetDetailViewModel>();


        return builder.Build();
    }
}
