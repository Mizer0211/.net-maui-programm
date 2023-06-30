using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Models
{
    public class PlanetModel
    {
        [PrimaryKey, AutoIncrement]
        public int PlanetID { get; set; }
        public string PlanetName { get; set; }
        public string PlanetDistance { get; set; }
        public string Atmosphere { get; set; }
        public string Diameter { get; set; }
        [Ignore]
        public string FullName => $"{PlanetName} {PlanetDistance}";
    }
}
