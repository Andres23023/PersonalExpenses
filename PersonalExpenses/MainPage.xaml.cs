using PersonalExpenses.ViewModels;

namespace PersonalExpenses
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = BindingContext as MainViewModel;
            vm.RefreshCategorias();
        }
    }
}
