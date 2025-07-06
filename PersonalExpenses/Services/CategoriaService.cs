using PersonalExpenses.Models;
using PersonalExpenses.Pages;
using System.Collections.ObjectModel;

namespace PersonalExpenses.Services
{
    public class CategoriaService
    {
        public ObservableCollection<Picker_Categorias> Categorias { get; set; } = new ObservableCollection<Picker_Categorias>
        {
            new Picker_Categorias {Categoria = "Inversiones" },
            new Picker_Categorias {Categoria = "Gastos" }
        };

//new Picker_Categorias { Categoria = nombre };
        public bool AgregarCategoria(string nombre)
        {
            if (Categorias.FirstOrDefault(c => c.Categoria == nombre) == null)
            {
                Categorias.Add(new Picker_Categorias { Categoria = nombre });
                return true;
            }
            else
                return false;
            
        }
        public void EliminarCategoria(string nombre)
        {
            var eliminar = Categorias.FirstOrDefault( c => c.Categoria == nombre);
            if (eliminar != null)
                Categorias.Remove(eliminar);
        }
    }
}
