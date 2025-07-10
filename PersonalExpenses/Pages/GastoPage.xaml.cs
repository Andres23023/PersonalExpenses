using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using PersonalExpenses.Models;
namespace PersonalExpenses.Pages;

public partial class GastoPage : ContentPage
{
	public GastoPage(GastoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		Eventos(vm);
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		var vm = BindingContext as GastoViewModel;
		vm.Refresh();
	}

	private void Eventos(GastoViewModel vm)
	{
        //		SNACKBAR
        vm.SnackBarInfo = async (mensaje, Bcolor) =>
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Bcolor,
                TextColor = Colors.Black,
                CornerRadius = new CornerRadius(20),
                Font = Microsoft.Maui.Font.SystemFontOfSize(14),
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14),
                CharacterSpacing = 0,

            };
            
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(mensaje, action: null, actionButtonText: "Ok", duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
        };

        //			EVENTO PARA ELIMINAR---
        vm.onEliminarGasto = async (gasto) =>
		{
            if (await DisplayAlert("Eliminar Gasto", $"Desea eliminar el gasto: {gasto.NomGasto}?", "Si", "Cancelar"))
                return true;
            return false;
        };
    }
}