using CommunityToolkit.Mvvm.ComponentModel;
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
        public void AgregarCategoria(string nombre)
        {
            if (Categorias.FirstOrDefault(c => c.Categoria == nombre) == null)
                Categorias.Add(new Picker_Categorias { Categoria = nombre });
            return;
            
        }
        public void EliminarCategoria(string nombre)
        {
            var eliminar = Categorias.FirstOrDefault( c => c.Categoria == nombre);
            if (eliminar != null)
                Categorias.Remove(eliminar);
            return;
        }
        public void EditarCategoria(Picker_Categorias categoria, string nuevoNombre)
        {
            var a = Categorias.FirstOrDefault(c => c.Categoria == nuevoNombre);
            if (Categorias.FirstOrDefault(c => c.Categoria == nuevoNombre) == null)
            {
                var index = Categorias.IndexOf(categoria);
                if (index >= 0)
                    Categorias[index].Categoria = nuevoNombre;
            }
            else
                return;
        }
    }
}
