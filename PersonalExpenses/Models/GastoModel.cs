using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenses.Models
{
    public class GastoModel
    {
        public string NomGasto { get; set; }
        public int Cantidad { get; set; }
        public string Categoria { get; set; }
        public static int suma { get; set; } = 0;
        public int GastoSuma()
        {
            suma += this.Cantidad;
            return suma;
        }
    }
}
