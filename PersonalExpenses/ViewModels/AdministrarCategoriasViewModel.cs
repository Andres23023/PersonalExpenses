﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PersonalExpenses.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using PersonalExpenses.Models;


namespace PersonalExpenses.ViewModels
{
    public partial class AdministrarCategoriasViewModel : ObservableObject
    {
        private CategoriaService categoriaService;
        private readonly GastoService gastoService;
        private readonly NotificacionesService _notificaciones;

        [ObservableProperty]
        ObservableCollection<CategoriaModel> categorias;


        //Constructor
        public AdministrarCategoriasViewModel(CategoriaService categoriaService,GastoService gastoService,NotificacionesService notificaciones) 
        {
            this.categoriaService = categoriaService;
            this.gastoService = gastoService;
            Categorias = categoriaService.Categorias;
            _notificaciones = notificaciones;

            Debug.WriteLine($"¿Command existe?: {EditarCategoriaCommand != null}");
        }

        [RelayCommand]
        public async Task AgregarCategoria()
        {
            string result = await _notificaciones.ShowPrompt("Nueva Categoria", "Ingresa el nombre de la nueva categoria", "Nueva categoria", 20, string.Empty);
            if (result == "")
            {
                _notificaciones?.ShowSnackBar("No se puede agregar una categoria vacia", _notificaciones.Error);
                return;
            }
            else if (result == null)
                return;
            //result.ToUpper();
            if (categoriaService.Categorias.Any(c => c.CategoriaNom.ToUpper() == result.ToUpper()))
            {
                _notificaciones?.ShowSnackBar("No se puede agregar una categoria repetida", _notificaciones.Info);
                return;
            }
            else
            {
                categoriaService.AgregarCategoria(result);
                _notificaciones?.ShowSnackBar($"Categoria {result} agregada correctamente", _notificaciones.Success);
            }

        }


        [RelayCommand]
        public async Task EliminarCategoria(CategoriaModel c)
        {
            if (c == null)
            {
                Debug.WriteLine("Categoria es null en EliminarCategoria");
                await _notificaciones.ShowSnackBar("Error: Categoría no válida", _notificaciones.Error);
                return;
            }

            if (gastoService.Gastos.Any(g => g.Categoria.IdCategoria == c.IdCategoria))
            {
                await _notificaciones.ShowSnackBar("No se puede eliminar la categoria porque tiene gastos asociados.", _notificaciones.Error);
                return;
            }
            else
            {
                bool result = await _notificaciones.ShowAlert("Eliminar Categoria", $"Desea eliminar la categoria {c.CategoriaNom}?");
                if (result)
                {
                    categoriaService.EliminarCategoria(c.IdCategoria);
                    await _notificaciones.ShowSnackBar($"Categoria {c.CategoriaNom} eliminada correctamente", _notificaciones.Success);
                }
                return;
            }
        }

        [RelayCommand]
        public async Task EditarCategoria(CategoriaModel categoria)
        {

            if(categoria == null)
            {
                //Debug.WriteLine("Categoria es nula en EditarCategoria.");
                _notificaciones?.ShowSnackBar("Error: La categoria es null", _notificaciones.Error);
                return;
            }

            string result = await _notificaciones.ShowPrompt("Editar Categoria", "Ingresa el nuevo nombre de la categoria", "Editar categoria", 20, categoria.CategoriaNom);

            if (result == null)
                return;
            else if (result == "")
            {
                _notificaciones?.ShowSnackBar("No se puede dejar el nombre en blanco", _notificaciones.Error);
                return;
            }
            else if (categoriaService.Categorias.Any(c => c.CategoriaNom == result))
            {
                _notificaciones?.ShowSnackBar("No se puede agregar una categoria repetida", _notificaciones.Error);
                return;
            }
            else
            {
                categoriaService.EditarCategoria(categoria.IdCategoria, result);
                _notificaciones?.ShowSnackBar($"Categoria {categoria.CategoriaNom} editada correctamente", _notificaciones.Success);
            }

        }
    }
}
