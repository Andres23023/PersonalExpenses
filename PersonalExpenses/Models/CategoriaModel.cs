
using CommunityToolkit.Mvvm.ComponentModel;

namespace PersonalExpenses.Pages
{
    public partial class CategoriaModel:ObservableObject
    {
        protected static int globalId;
        [ObservableProperty]
        public string categoriaNom;
        [ObservableProperty]
        public int idCategoria;
        public CategoriaModel(string Categoria)
        {
            this.CategoriaNom = Categoria;
            this.idCategoria = Interlocked.Increment(ref globalId);
        }
    }
}
