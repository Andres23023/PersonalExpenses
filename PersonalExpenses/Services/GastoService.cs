using System.Collections.ObjectModel;
using PersonalExpenses.Models;
using PersonalExpenses.Services;

namespace PersonalExpenses.Pages
{
    public class GastoService
    {
        //public ObservableCollection<Usuario> Usuarios { get; set; } = new ObservableCollection<Usuario>();
        private SerializerService serializerService;
        public ObservableCollection<GastoModel> Gastos{ get; set; }

        public GastoService()
        {
            serializerService = new SerializerService();
            Gastos = serializerService.CargarGastos() ?? new ObservableCollection<GastoModel>();

        }
        //public ObservableCollection<GastoModel> Gastos { get; set; } = new ObservableCollection<GastoModel>();

        public void AgregarGasto(GastoModel gasto)
        {
            Gastos.Add(gasto);
            serializerService.GuardarGastos(Gastos);
        }

        public void EliminarGasto(GastoModel gasto)
        {
            Gastos.Remove(gasto);
            serializerService.GuardarGastos(Gastos);
        }
    }

}
