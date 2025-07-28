using System.Collections.ObjectModel;
using PersonalExpenses.Models;
using PersonalExpenses.Services;

namespace PersonalExpenses.Services
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
            if (Gastos == null)
                Gastos = new ObservableCollection<GastoModel>();

            if (gasto != null) 
            {
                Gastos.Add(gasto);
                serializerService?.GuardarGastos(Gastos);
            }
            //Gastos.Add(gasto);
        }

        public void EliminarGasto(GastoModel gasto)
        {
            if (gasto != null && Gastos?.Contains(gasto) == true)
            {
                Gastos.Remove(gasto);
                serializerService?.GuardarGastos(Gastos);
            }
            //Gastos.Remove(gasto);
        }
    }

}
