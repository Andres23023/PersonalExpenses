using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PersonalExpenses.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace PersonalExpenses.Pages
{
    public partial class GastoViewModel: ObservableObject
    {
        private readonly GastoService gastoService;
        

        [ObservableProperty]
        ObservableCollection<GastoModel> gastos;
        [ObservableProperty]
        int suma;
        public GastoViewModel(GastoService gastoService)
        {
            this.gastoService = gastoService;
            Gastos = gastoService.Gastos;
        }
        public Action<string, Color> SnackBarInfo;
        public Color Error = Colors.Red;
        //public Color Info = Colors.Orange;
        public Color Success = Colors.Green;


        public void Refresh()
        {
            int nuevaSuma = 0;
            foreach (var gasto in Gastos)
            {
                nuevaSuma += gasto.Cantidad;
            }
            Suma = nuevaSuma;
        }
        public Func<GastoModel,Task<bool>> onEliminarGasto;
        [RelayCommand]
        public async Task EliminarGasto(GastoModel gasto)
        {
            bool response = await onEliminarGasto?.Invoke(gasto);
            if (response)
            {
                gastoService.EliminarGasto(gasto);
                SnackBarInfo?.Invoke($"Gasto {gasto.NomGasto} eliminado correctamente!", Success);
                Refresh();
            }
            return;
        }

    }
}
