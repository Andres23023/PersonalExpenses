
using CommunityToolkit.Mvvm.ComponentModel;
using PersonalExpenses.Pages;

namespace PersonalExpenses.Models
{
    public partial class GastoModel:ObservableObject
    {

        [ObservableProperty]
        public string nomGasto;
        [ObservableProperty]
        public int cantidad;
        [ObservableProperty]
        public Picker_Categorias categoria;
    }
}
