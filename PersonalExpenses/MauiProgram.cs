using Microsoft.Extensions.Logging;
using PersonalExpenses.Models;
using PersonalExpenses.Pages;

namespace PersonalExpenses
{
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

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            //TabbedPage
            builder.Services.AddSingleton<TabbedPageT>();
            //Paginas
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<GastoPage>();
            builder.Services.AddSingleton<AdministrarCategorias>();

            //ViewModels
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<GastoViewModel>();

            //Services
            builder.Services.AddSingleton<GastoService>();

            //Models
            builder.Services.AddTransient<GastoModel>();





#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
