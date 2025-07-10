using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using PersonalExpenses.ViewModels;

namespace PersonalExpenses.Pages;

public partial class AdministrarCategorias : ContentPage
{
	public AdministrarCategorias(AdministrarCategoriasViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

        Eventos(vm);
    }
   
    private void Eventos(AdministrarCategoriasViewModel vm)
    {
        // INFO 
        vm.SnackBarInfo = async (mensaje,Bcolor) =>
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Bcolor,
                TextColor = Colors.Black,
                //ActionButtonTextColor = Colors.Yellow,
                CornerRadius = new CornerRadius(20),
                Font = Microsoft.Maui.Font.SystemFontOfSize(14),
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14),
                CharacterSpacing = 0,
                
            };

            //string text = "This is a Snackbar";
            //string actionButtonText = "Click Here to Dismiss";
            //Action action = async () => await DisplayAlert("Snackbar ActionButton Tapped", "The user has tapped the Snackbar ActionButton", "OK");
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(mensaje,action:null , actionButtonText:"Ok", duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
            //await DisplayAlert("Informacion", mensaje, "Ok");
        };
        //          AGREGAR CATEGORIA ---
        vm.OnCategoriaMade = async () =>
        {
            string result = await DisplayPromptAsync("Nueva Categoria", "Ingresa el nombre de la nueva categoria", "Ok", "Cancelar", "Nueva categoria", 20, default, string.Empty);
            if (result == "")
                return "";
            else if (result == null)
                return null;
            else
                return result;
            //await DisplayAlert("Error!", "No se puede ", "Ok");
        };

        //          ELIMINAR CATEGORIA ---
        vm.OnCategoriaDelete = async (c) =>
        {
            //bool response = await DisplayAlert("Eliminar Categoria", mensaje, "Ok","Cancelar");
            if (await DisplayAlert("Eliminar Categoria", $"Desea eliminar la categoria {c.Categoria}?", "Si", "Cancelar"))
                return true;
            return false;
        };
        
        //          EDITAR CATEGORIA ---
        vm.OnCategoriaEdit = async (categoria) =>
        {
            string result = await DisplayPromptAsync("Editar Categoria", "Ingresa el nuevo nombre de la categoria", "Ok", "Cancelar", "Editar categoria", 20, default, categoria.Categoria);

            if (string.IsNullOrWhiteSpace(result))
            {
                vm.SnackBarInfo?.Invoke("No se puede dejar el nombre en blanco", vm.Error);
                return null;
            } else if(vm.Categorias.Any(c => c.Categoria == result))
            {
                vm.SnackBarInfo?.Invoke("No se puede agregar una categoria repetida", vm.Error);
                return null;
            }
            else
                return result;

        };
    }

}