using SQLiteDemo.ViewModels;

namespace SQLiteDemo.Views;

public partial class AddUpdatePlanetDetail : ContentPage
{
    public AddUpdatePlanetDetail(AddUpdatePlanetDetailViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}