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