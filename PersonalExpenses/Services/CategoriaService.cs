using PersonalExpenses.Pages;
using System.Collections.ObjectModel;

namespace PersonalExpenses.Services
{
    public class CategoriaService
    {
        private SerializerService serializerService;

        public ObservableCollection<CategoriaModel> Categorias { get; set; }

        public CategoriaService()
        {
            serializerService = new SerializerService();
            Categorias = serializerService.CargarCategorias() ?? new ObservableCollection<CategoriaModel>
            {
                new CategoriaModel("Gastos"),
                new CategoriaModel("Inversiones")
            };
        }
        public void AgregarCategoria(string nombre)
        {
            Categorias.Add(new CategoriaModel(Categoria: nombre));
            serializerService?.GuardarCategorias(Categorias);
        }
        public void EliminarCategoria(int id)
        {
            Categorias.Remove(Categorias.FirstOrDefault(c => c.IdCategoria == id));
            serializerService?.GuardarCategorias(Categorias);
        }
        public void EditarCategoria(int id, string nuevoNombre)
        {
            Categorias.FirstOrDefault(c => c.IdCategoria == id).CategoriaNom = nuevoNombre;
            serializerService?.GuardarCategorias(Categorias);
        }
    }
}
