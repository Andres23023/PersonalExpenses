using CommunityToolkit.Mvvm.ComponentModel;
using PersonalExpenses.Models;
using PersonalExpenses.Pages;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

namespace PersonalExpenses.Services
{
    public class SerializerService
    {   
        //Categorias
        public void GuardarCategorias(ObservableCollection<CategoriaModel> categorias)
        {
            var json = JsonSerializer.Serialize(categorias);
            Preferences.Set("ItemsCategorias", json);
        }
        public ObservableCollection<CategoriaModel>? CargarCategorias()
        {
            try
            {
                if (Preferences.ContainsKey("ItemsCategorias"))
                {
                    var json = Preferences.Get("ItemsCategorias", string.Empty);
                    if (string.IsNullOrEmpty(json))
                        return null;
                    var items = JsonSerializer.Deserialize<ObservableCollection<CategoriaModel>>(json);
                    return items;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al deserializar categorías: {ex.Message}");
                return null;
            }


            /* if (Preferences.ContainsKey("ItemsCategorias"))
             {
                 var json = Preferences.Get("ItemsCategorias", string.Empty);
                 var items = JsonSerializer.Deserialize<ObservableCollection<CategoriaModel>>(json);
                 return items;
             }
             else
                 return null;*/
        }
        //Gastos
        public void GuardarGastos(ObservableCollection<GastoModel> gasto)
        {
            var json = JsonSerializer.Serialize(gasto);
            Preferences.Set("ItemsGastos", json);
        }
        public ObservableCollection<GastoModel>? CargarGastos()
        {
            try
            {
                if (Preferences.ContainsKey("ItemsGastos"))
                {
                    var json = Preferences.Get("ItemsGastos", string.Empty);
                    if (string.IsNullOrEmpty(json))
                        return null;
                    var items = JsonSerializer.Deserialize<ObservableCollection<GastoModel>>(json);
                    return items;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al deserializar gastos: {ex.Message}");
                return null;
            }


            /* if (Preferences.ContainsKey("ItemsGastos"))
             {
                 var json = Preferences.Get("ItemsGastos", string.Empty);
                 var items = JsonSerializer.Deserialize<ObservableCollection<GastoModel>>(json);
                 return items;
             }
             else
                 return null;*/
        }
    }
}
