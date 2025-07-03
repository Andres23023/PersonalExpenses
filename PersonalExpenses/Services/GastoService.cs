using System.Collections.ObjectModel;
using PersonalExpenses.Models;

namespace PersonalExpenses.Pages
{
    public class GastoService
    {
        //public ObservableCollection<Usuario> Usuarios { get; set; } = new ObservableCollection<Usuario>();
        public ObservableCollection<GastoModel> Gastos { get; set; } = new ObservableCollection<GastoModel>();
    }

}
