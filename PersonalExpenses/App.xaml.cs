using PersonalExpenses.Pages;
namespace PersonalExpenses
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new TabbedPageT();
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}