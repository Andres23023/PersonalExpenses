using CommunityToolkit.Mvvm.Input;
using PersonalExpenses.ViewModels;

namespace PersonalExpenses.Pages;

public partial class AdministrarCategorias : ContentPage
{
	public AdministrarCategorias(AdministrarCategoriasViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    var vm = BindingContext as AdministrarCategoriasViewModel;
    //    //vm.Refresh();
    //}
    async void AddCategoria(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Categorias", "Agrega una nueva categoria", "Ok", "Cancelar", "Añade tu categoria", 20, default);

        var vm = BindingContext as AdministrarCategoriasViewModel;
        bool response = vm.AgregarCategoria(result);
        if (!response)
        {
            await DisplayAlert("Error!", "Categoria repetida o en blanco", "Ok");
        }
    }
    
    
    async void DeleteCategoria(object sender, EventArgs e)
    {

        var vm = BindingContext as AdministrarCategoriasViewModel;
        var item = (sender as SwipeItem)?.CommandParameter as Picker_Categorias;

        bool response = vm.EliminarCategoria(item.Categoria);
        if (response)
        {
            //await DisplayAlert("exito!", "", "Ok");
            return;
        }
        else
        {
            await DisplayAlert("Error!", "La categoria pertenece a un gasto", "Ok");
        }
    }

}