using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PersonalExpenses.Models;
using PersonalExpenses.Services;
using System.Collections.ObjectModel;

namespace PersonalExpenses.ViewModels
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
    }
}
