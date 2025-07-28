using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace PersonalExpenses.Services
{
    public class NotificacionesService
    {
        public Color Error { get; } = Colors.Red;
        public Color Info { get; } = Colors.Orange;
        public Color Success { get; } = Colors.Green;
        public async Task ShowSnackBar(string mensaje, Color bcolor)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = bcolor,
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

            var snackbar = Snackbar.Make(mensaje, action: null, actionButtonText: "Ok", duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
            //await DisplayAlert("Informacion", mensaje, "Ok");
        }
        public async Task<bool> ShowAlert(string titulo, string mensaje)
        {
            var mainPage = App.Current?.Windows.FirstOrDefault()?.Page;
            if (mainPage == null)
                return false;


            return await MainThread.InvokeOnMainThreadAsync(() =>
                mainPage.DisplayAlert(titulo, mensaje, "Ok", "Cancelar")
            );

            //if (App.Current?.MainPage == null)
            //    return false;

            //return await MainThread.InvokeOnMainThreadAsync(() =>
            //    App.Current.MainPage.DisplayAlert(titulo, mensaje, "Ok", "Cancelar")
            //);
            //return await App.Current.MainPage.DisplayAlert(titulo, mensaje, "Ok", "Cancelar");
        }
        public async Task<string> ShowPrompt(string titulo, string mensaje, string placeholder = "", int maxLength = 20, string initialValue = "")
        {

            var mainPage = App.Current?.MainPage; // Simplifica y usa MainPage directamente
            if (mainPage == null)
            {
                //Debug.WriteLine("MainPage no está disponible");
                return null;
            }

            return await MainThread.InvokeOnMainThreadAsync(() =>
                mainPage.DisplayPromptAsync(titulo, mensaje, "Ok", "Cancelar", placeholder, maxLength, Keyboard.Default, initialValue)
            );


            //if (App.Current?.MainPage == null)
            //    return null;

            //return await MainThread.InvokeOnMainThreadAsync(() =>
            //    App.Current.MainPage.DisplayPromptAsync(titulo, mensaje, "Ok", "Cancelar", placeholder, maxLength, default, initialValue)
            //);

            //return await App.Current.MainPage.DisplayPromptAsync(titulo, mensaje, "Ok", "Cancelar", placeholder, maxLength, default, initialValue);
        }
    }
}
