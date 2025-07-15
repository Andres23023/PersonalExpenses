using Microsoft.Extensions.Logging;
using PersonalExpenses.Models;
using PersonalExpenses.Pages;
using PersonalExpenses.Services;
using PersonalExpenses.ViewModels;

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
            builder.Services.AddSingleton<AdministrarCategoriasViewModel>();

            //Services
            builder.Services.AddSingleton<GastoService>();
            builder.Services.AddSingleton<CategoriaService>();
            builder.Services.AddSingleton<NotificacionesService>();

            //Models
            //builder.Services.AddTransient<GastoModel>();





#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
