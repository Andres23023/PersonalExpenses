using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PersonalExpenses.Pages
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<RBTN_Categorias> rbtnCategorias;
        IConnectivity connectivity;
        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<String>();
            this.connectivity = connectivity;
            RbtnCategorias = new ObservableCollection<RBTN_Categorias>
            {
                new RBTN_Categorias { Id = 1, Categoria = "Inversiones" },
                new RBTN_Categorias { Id = 2, Categoria = "Gastos" }
            };
            //LoadItems();
        }
        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [RelayCommand]
        async Task AddExpense()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Uh Oh!", "No hay acceso a internet", "Ok");
                return;
            }

            Items.Add(Text);
            //SaveItems();
            Text = string.Empty;
        }
        [RelayCommand]
        void Delete(string s)
        {
            if (Items.Contains(s))
            {
                Items.Remove(s);
                //SaveItems();
            }
        }
        //[RelayCommand]
        //async Task Tap(string s)
        //{
        //    await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
        //}

        //void LoadItems()
        //{
        //    if (Preferences.ContainsKey("ToDoItems"))
        //    {
        //        var json = Preferences.Get("ToDoItems", string.Empty);
        //        var items = JsonSerializer.Deserialize<ObservableCollection<string>>(json);

        //        if (items != null)
        //            Items = items;
        //        else
        //            Items = new ObservableCollection<string>();
        //    }
        //    else
        //    {
        //        Items = new ObservableCollection<string>();
        //    }
        //}

        //void SaveItems()
        //{
        //    var json = JsonSerializer.Serialize(Items);
        //    Preferences.Set("ToDoItems", json);
        //}

        
        //public ObservableCollection<RBTN_Categorias> RBTNCategorias  => new ObservableCollection<RBTN_Categorias>
        //{
        //    new RBTN_Categorias{Id=1, Categoria = "Inversiones"},
        //    new RBTN_Categorias{Id=2, Categoria = "Gastos"}
        //};
        

    }
}
