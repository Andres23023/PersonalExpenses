using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalExpenses.Models;

namespace PersonalExpenses.Pages
{
    public class GastoService
    {
        //public ObservableCollection<Usuario> Usuarios { get; set; } = new ObservableCollection<Usuario>();
        public ObservableCollection<GastoModel> Gastos { get; set; } = new ObservableCollection<GastoModel>();
    }

}
