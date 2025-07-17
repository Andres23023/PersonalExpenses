using PersonalExpenses.Pages;
using System.Collections.ObjectModel;

namespace PersonalExpenses.Services
{
    public class CategoriaService
    {
        public ObservableCollection<CategoriaModel> Categorias { get; set; } = new ObservableCollection<CategoriaModel>
        {
            new CategoriaModel ("Gastos"),
            new CategoriaModel ("Inversiones")
        };
        public void AgregarCategoria(string nombre)
        {
            Categorias.Add(new CategoriaModel(Categoria: nombre));
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
