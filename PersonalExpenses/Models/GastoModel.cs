using CommunityToolkit.Mvvm.ComponentModel;

namespace PersonalExpenses.Models
{
    public partial class GastoModel:ObservableObject
    {

        [ObservableProperty]
        public string nomGasto;
        [ObservableProperty]
        public int cantidad;
        [ObservableProperty]
        public CategoriaModel categoria;
    }
}
