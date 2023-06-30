using SQLiteDemo.ViewModels;

namespace SQLiteDemo.Views;

public partial class PlanetListPage : ContentPage
{
    private PlanetListPageViewModel _viewMode;
    public PlanetListPage(PlanetListPageViewModel viewModel)
	{
		InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetPlanetListCommand.Execute(null);
    }
}