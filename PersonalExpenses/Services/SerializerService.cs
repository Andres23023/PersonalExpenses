using CommunityToolkit.Mvvm.ComponentModel;
using PersonalExpenses.Pages;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace PersonalExpenses.Services
{
    public class SerializerService
    {   
        public void GuardarCategorias(ObservableCollection<CategoriaModel> categorias)
        {
            var json = JsonSerializer.Serialize(categorias);
            Preferences.Set("ItemsCategorias", json);
        }
        public ObservableCollection<CategoriaModel>? CargarCategorias()
        {
            if (Preferences.ContainsKey("ItemsCategorias"))
            {
                var json = Preferences.Get("ItemsCategorias", string.Empty);
                var items = JsonSerializer.Deserialize<ObservableCollection<CategoriaModel>>(json);
                return items;
            }
            else
                return null;
        }
    }
}
