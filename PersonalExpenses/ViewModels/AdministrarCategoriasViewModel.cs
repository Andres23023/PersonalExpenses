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

        
        public bool AgregarCategoria(string categoria)
        {
            if(string.IsNullOrWhiteSpace(categoria))
                return false;
            bool response = categoriaService.AgregarCategoria(categoria);
            if (response == false)
                return false;
            else return true;

        }
        public bool EliminarCategoria(string c)
        {
            if (gastoService.Gastos.Any(g => g.Categoria == c))
            {
                return false;
            }
            else
            {
                categoriaService.EliminarCategoria(c);
                return true;
            }
        }

        [RelayCommand]
        public async void EditarCategoria(Picker_Categorias categoria)
        {
            await App.Current?.Windows?.FirstOrDefault()?.Page.DisplayPromptAsync("Editar Categoria", "Ingresa el nuevo nombre de la categoria", "Ok", "Cancelar", "Editar categoria", 20, default, categoria.Categoria);
            
        }
    }
}
