using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using PersonalExpenses.Services;
using PersonalExpenses.ViewModels;

namespace PersonalExpenses.Pages;

public partial class AdministrarCategorias : ContentPage
{
    public AdministrarCategorias(AdministrarCategoriasViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }

}