using SQLiteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Services
{
    public interface IPlanetService
    {
        Task<List<PlanetModel>> GetPlanetList();
        Task<int> AddPlanet(PlanetModel planetModel);
        Task<int> DeletePlanet(PlanetModel planetModel);
        Task<int> UpdatePlanet(PlanetModel planetModel);
    }
}
