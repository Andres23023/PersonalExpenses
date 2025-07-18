using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PersonalExpenses.Models;
using PersonalExpenses.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace PersonalExpenses.Pages
{
    public partial class GastoViewModel: ObservableObject
    {
        private readonly GastoService gastoService;
        private readonly NotificacionesService _notificaciones;

        [ObservableProperty]
        ObservableCollection<GastoModel> gastos;
        [ObservableProperty]
        int suma;
        public GastoViewModel(GastoService gastoService,NotificacionesService notificaciones)
        {
            this.gastoService = gastoService;
            Gastos = gastoService.Gastos;
            _notificaciones = notificaciones;
        }


        public void Refresh()
        {
            int nuevaSuma = 0;
            if (Gastos == null)
                return;
            foreach (var gasto in Gastos)
            {
                nuevaSuma += gasto.Cantidad;
            }
            Suma = nuevaSuma;
        }
        [RelayCommand]
        public async Task EliminarGasto(GastoModel gasto)
        {
            bool response = await _notificaciones.ShowAlert("Eliminar Gasto", $"Desea eliminar el gasto: {gasto.NomGasto}?");
            if (response)
            {
                gastoService.EliminarGasto(gasto);
                _notificaciones.ShowSnackBar($"Gasto {gasto.NomGasto} eliminado correctamente!", _notificaciones.Success);
                Refresh();
            }
            return;
        }

    }
}
