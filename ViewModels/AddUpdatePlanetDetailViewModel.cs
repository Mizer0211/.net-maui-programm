using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLiteDemo.Models;
using SQLiteDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.ViewModels
{
    [QueryProperty(nameof(PlanetDetail), "PlanetDetail")]
    public partial class AddUpdatePlanetDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private PlanetModel _planetDetail = new PlanetModel();

        private readonly IPlanetService _planetService;
        public AddUpdatePlanetDetailViewModel(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [RelayCommand]
        public async void AddUpdatePlanet()
        {
            int response = -1;
            if (PlanetDetail.PlanetID > 0)
            {
                response = await _planetService.UpdatePlanet(PlanetDetail);
            }
            else
            {
                response = await _planetService.AddPlanet(new Models.PlanetModel
                {
                    Atmosphere = PlanetDetail.Atmosphere,
                    PlanetName = PlanetDetail.PlanetName,
                    PlanetDistance = PlanetDetail.PlanetDistance,
                    Diameter = PlanetDetail.Diameter
                });
            }

        

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Planet Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }

    }
}
