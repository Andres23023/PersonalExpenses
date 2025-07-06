using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using Intents;
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


            
        public void Refresh()
        {
            int nuevaSuma = 0;
            foreach (var gasto in Gastos)
            {
                nuevaSuma += gasto.Cantidad;
            }
            Suma = nuevaSuma;
        }



    }
}
