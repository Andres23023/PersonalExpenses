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

        
    }
}
