using Microsoft.Extensions.DependencyInjection;
using PersonalExpenses.Pages;
namespace PersonalExpenses
{
    public partial class App : Application
    {
        
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            MainPage = serviceProvider.GetService<TabbedPageT>();

        }
    }
}