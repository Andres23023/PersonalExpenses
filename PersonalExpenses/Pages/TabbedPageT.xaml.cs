using Microsoft.Extensions.DependencyInjection;

namespace PersonalExpenses.Pages;

public partial class TabbedPageT : TabbedPage
{
	public TabbedPageT(IServiceProvider serviceProvider)
	{
		InitializeComponent();

        var mainPage = new NavigationPage(serviceProvider.GetService<MainPage>())
        {
            Title = "Inicio",
            IconImageSource = "home.png"
        };
        var gastos = new NavigationPage(serviceProvider.GetService<GastoPage>())
        {
            Title = "Gastos",
            IconImageSource = "gastos.png"
        };
        var categorias = new NavigationPage(serviceProvider.GetService<AdministrarCategorias>())
        {
            Title = "Categorias",
            IconImageSource = "categoria.png"
        };

        Children.Add(mainPage);
        Children.Add(gastos);
        Children.Add(categorias);
    }
}