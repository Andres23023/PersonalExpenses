using PersonalExpenses.Models;
namespace PersonalExpenses.Pages;

public partial class GastoPage : ContentPage
{
	public GastoPage(GastoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		var vm = BindingContext as GastoViewModel;
		vm.Refresh();
	}

	async void DeleteGasto(Object sender, EventArgs e)
	{
		bool response = await DisplayAlert("Eliminar Gasto", "¿Seguro que quieres eliminar este gasto?", "Si", "No");
		if (response)
		{
			var item = (sender as SwipeItem)?.CommandParameter as GastoModel;
            var vm = BindingContext as GastoViewModel;
			vm.EliminarGasto(item);
        }
    }
}