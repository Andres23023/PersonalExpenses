﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PersonalExpenses.Models;
using PersonalExpenses.Services;
using System.Collections.ObjectModel;

namespace PersonalExpenses.Pages
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<CategoriaModel> pickerCategorias;
        private readonly GastoService gastoService;
        private readonly CategoriaService categoriaService;
        private readonly NotificacionesService _notificaciones;
        IConnectivity connectivity;

        //Constructor
        public MainViewModel(IConnectivity connectivity, GastoService gastoService,CategoriaService categoriaService,NotificacionesService notificaciones)
        {
            this.connectivity = connectivity;

            this.gastoService = gastoService;
            this.categoriaService = categoriaService;
            PickerCategorias = categoriaService.Categorias;
            _notificaciones = notificaciones;
        }
        [ObservableProperty]
        string txtGasto;
        [ObservableProperty]
        int txtCantidad;
        [ObservableProperty]
        CategoriaModel itemCategoria;

        

        [ObservableProperty]
        string lblPrueba;

        [RelayCommand]
        async void AddExpense()
        {
            if (string.IsNullOrWhiteSpace(TxtGasto) || TxtCantidad <= 0 || ItemCategoria == null)
            {
                bool res = await _notificaciones.ShowAlert("Error", "Por favor, complete todos los campos antes de agregar un gasto.");

                return;
            }

            GastoModel gasto = new GastoModel { Cantidad = TxtCantidad, NomGasto = TxtGasto, Categoria = ItemCategoria};
            gastoService.AgregarGasto(gasto);
            

            await _notificaciones.ShowSnackBar($"Gasto {gasto.NomGasto} agregado correctamente", _notificaciones.Success);
            //Ponerlos vacios una vez agregados
            TxtGasto = string.Empty;
            TxtCantidad = 0;
            ItemCategoria = null;

        }
        public void RefreshCategorias()
        {
            PickerCategorias = new ObservableCollection<CategoriaModel>(categoriaService.Categorias);
        }
        //[RelayCommand]
        //void Delete(string s)
        //{
        //    if (Gastos.Contains(s))
        //    {
        //        Gastos.Remove(s);
        //        //SaveItems();
        //    }
        //}
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
