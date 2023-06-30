using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLiteDemo.Models;
using SQLiteDemo.Services;
using SQLiteDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.ViewModels
{
    public partial class PlanetListPageViewModel : ObservableObject
    {
        //public static List<PlanetModel> PlanetsListForSearch { get; private set; } = new List<PlanetModel>();
        //public ObservableCollection<PlanetModel> Planets { get; set; } = new ObservableCollection<PlanetModel>();

        [ObservableProperty] private List<PlanetModel> planetsListForSearch;
        [ObservableProperty] private ObservableCollection<PlanetModel> planets;

        private readonly IPlanetService _planetService;
        public PlanetListPageViewModel(IPlanetService planetService)
        {
            _planetService = planetService;
        }



        [RelayCommand]
        public async void GetPlanetList()
        {
            var planetList = await _planetService.GetPlanetList();
            Planets = new ObservableCollection<PlanetModel>(planetList.OrderBy(f => f.FullName));
            PlanetsListForSearch = planetList;
            /*           
                       Planets.Clear();
                       var planetList = await _planetService.GetPlanetList();
                       if (planetList?.Count > 0)
                       {
                           planetList = planetList.OrderBy(f => f.FullName).ToList();
                           foreach (var planet in planetList)
                           {
                               Planets.Add(planet);
                           }
                           PlanetsListForSearch.Clear();
                           PlanetsListForSearch.AddRange(planetList);
                       }
            */
        }


        [RelayCommand]
        public async void AddUpdatePlanet()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdatePlanetDetail));
        }

        [RelayCommand]
        public async void EditPlanet(PlanetModel planetModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("PlanetDetail", planetModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdatePlanetDetail), navParam);
        }

        [RelayCommand]
        public async void DeletePlanet(PlanetModel planetModel)
        {
            var delResponse = await _planetService.DeletePlanet(planetModel);
            if (delResponse > 0)
            {
                GetPlanetList();
            }
        }


        [RelayCommand]
        public async void DisplayAction(PlanetModel planetModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("PlanetDetail", planetModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdatePlanetDetail), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _planetService.DeletePlanet(planetModel);
                if (delResponse > 0)
                {
                    GetPlanetList();
                }
            }
        }
    }
}
