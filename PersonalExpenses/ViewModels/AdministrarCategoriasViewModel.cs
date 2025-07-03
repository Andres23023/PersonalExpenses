using CommunityToolkit.Mvvm.ComponentModel;
using PersonalExpenses.Models;
using PersonalExpenses.Pages;
using PersonalExpenses.Services;
using System.Collections.ObjectModel;


namespace PersonalExpenses.ViewModels
{
    public partial class AdministrarCategoriasViewModel : ObservableObject
    {
        private readonly CategoriaService categoriaService;
        [ObservableProperty]
        ObservableCollection<Picker_Categorias> categorias;

        //Constructor
        public AdministrarCategoriasViewModel(CategoriaService categoriaService) 
        {
            this.categoriaService = categoriaService;
            Categorias = categoriaService.Categorias;
            //MainViewModel.
        }

    }
}
