using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using PersonalExpenses.Services;
namespace PersonalExpenses.Pages;

public partial class GastoPage : ContentPage
{
    public GastoPage(GastoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
	protected override void OnAppearing()
	{
		base.OnAppearing();
		var vm = BindingContext as GastoViewModel;
		vm.Refresh();
	}
}