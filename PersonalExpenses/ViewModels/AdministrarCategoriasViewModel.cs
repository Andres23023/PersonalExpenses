using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui;
using PersonalExpenses.Models;
using PersonalExpenses.Pages;
using PersonalExpenses.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace PersonalExpenses.ViewModels
{
    public partial class AdministrarCategoriasViewModel : ObservableObject
    {
        private CategoriaService categoriaService;
        private readonly GastoService gastoService;
        [ObservableProperty]
        ObservableCollection<Picker_Categorias> categorias;

        //Constructor
        public AdministrarCategoriasViewModel(CategoriaService categoriaService,GastoService gastoService) 
        {
            this.categoriaService = categoriaService;
            this.gastoService = gastoService;
            Categorias = categoriaService.Categorias;
        }
        //public Func<string, Task> MostrarMensajeAlert;
        public Action<string,Color> SnackBarInfo;
        public Color Error = Colors.Red;
        public Color Info = Colors.Orange;
        public Color Success = Colors.Green;

        public Func<Task<string>> OnCategoriaMade;
        [RelayCommand]
        public async Task AgregarCategoria()
        {
            string result = await OnCategoriaMade?.Invoke();
            if (result == "")
            {
                SnackBarInfo?.Invoke("No se puede agregar una categoria en blanco", Info);
                return;
            }
            else if (result == null)
                return;

            if (categoriaService.Categorias.Any(c => c.Categoria == result))
            {
                SnackBarInfo?.Invoke("No se puede agregar una categoria repetida", Info);
                return;
            }
            else
            {
                categoriaService.AgregarCategoria(result);
                SnackBarInfo?.Invoke($"Categoria {result} agregada correctamente", Success);
            }

        }

        public Func<Picker_Categorias,Task<bool>> OnCategoriaDelete;

        [RelayCommand]
        public async Task EliminarCategoria(Picker_Categorias c)
        {
            if (gastoService.Gastos.Any(g => g.Categoria == c.Categoria))
            {
                SnackBarInfo?.Invoke("No se puede eliminar la categoria porque tiene gastos asociados.", Error);
                return;
            }
            else
            {
                bool result = await OnCategoriaDelete?.Invoke(c);
                if (result)
                {
                    categoriaService.EliminarCategoria(c.Categoria);
                    SnackBarInfo?.Invoke($"Categoria {c.Categoria} eliminada correctamente", Success);
                }
            }
            
        }

        public Func<Picker_Categorias, Task<string>> OnCategoriaEdit;

        [RelayCommand]
        public async Task EditarCategoria(Picker_Categorias categoria)
        {
            string result = await OnCategoriaEdit?.Invoke(categoria);
            if (result == null)
                return;
            else
            {
                categoriaService.EditarCategoria(categoria, result);
                SnackBarInfo?.Invoke($"Categoria {categoria.Categoria} editada correctamente", Success);
            }

        }
    }
}
