using SQLite;
using SQLiteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Services
{
    public class PlanetService : IPlanetService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Planet.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<PlanetModel>();
            }
        }

        public async Task<int> AddPlanet(PlanetModel planetModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(planetModel);
        }

        public async Task<int> DeletePlanet(PlanetModel planetModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(planetModel);
        }

        public async Task<List<PlanetModel>> GetPlanetList()
        {
            await SetUpDb();
            var planetList = await _dbConnection.Table<PlanetModel>().ToListAsync();
            return planetList;
        }

        public async Task<int> UpdatePlanet(PlanetModel planetModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(planetModel);
        }
    }
}
