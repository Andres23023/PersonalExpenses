using PersonalExpenses.Pages;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace PersonalExpenses
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
