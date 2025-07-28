using System.Collections.ObjectModel;
using System.Diagnostics;
using PersonalExpenses.Models;

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
            if(Categorias == null)
                Categorias = new ObservableCollection<CategoriaModel>();

            Categorias.Add(new CategoriaModel(Categoria: nombre));
            serializerService?.GuardarCategorias(Categorias);
        }
        public void EliminarCategoria(int id)
        {
            //Categorias.Remove(Categorias.FirstOrDefault(c => c.IdCategoria == id));

            if (Categorias == null)
            {
                //Debug.WriteLine("Categorias es null en EliminarCategoria");
                return;
            }
            var categoria = Categorias.FirstOrDefault(c => c.IdCategoria == id);
            if (categoria != null)
            {
                Categorias.Remove(categoria);
                serializerService?.GuardarCategorias(Categorias);
            }
            else
            {
                Debug.WriteLine($"No se encontró la categoría con ID {id}");
            }

        }
        public void EditarCategoria(int id, string nuevoNombre)
        {
            //Categorias.FirstOrDefault(c => c.IdCategoria == id).CategoriaNom = nuevoNombre;

            if (Categorias == null)
            {
                //Debug.WriteLine("Categorias es null en EditarCategoria");
                return;
            }
            var categoria = Categorias.FirstOrDefault(c => c.IdCategoria == id);
            if (categoria != null)
            {
                categoria.CategoriaNom = nuevoNombre;
                serializerService?.GuardarCategorias(Categorias);
            }
            else
                return;
        }
    }
}
