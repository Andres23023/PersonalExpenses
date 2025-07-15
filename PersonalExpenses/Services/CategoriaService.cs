using PersonalExpenses.Pages;
using System.Collections.ObjectModel;

namespace PersonalExpenses.Services
{
    public class CategoriaService
    {
        public ObservableCollection<Picker_Categorias> Categorias { get; set; } = new ObservableCollection<Picker_Categorias>
        {
            new Picker_Categorias ("Gastos"),
            new Picker_Categorias ("Inversiones")
        };
        public void AgregarCategoria(string nombre)
        {
            Categorias.Add(new Picker_Categorias(Categoria: nombre));
        }
        public void EliminarCategoria(int id)
        {
            Categorias.Remove(Categorias.FirstOrDefault(c => c.IdCategoria == id));
        }
        public void EditarCategoria(int id, string nuevoNombre)
        {
            Categorias.FirstOrDefault(c => c.IdCategoria == id).CategoriaNom = nuevoNombre;
        }
    }
}
