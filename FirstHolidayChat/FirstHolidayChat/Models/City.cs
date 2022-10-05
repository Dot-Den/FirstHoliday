using System;
using System.Collections.Generic;

namespace FirstHolidayChat.Models
{
    public partial class City
    {
        public City()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int CityId { get; set; }
        public string HolCity { get; set; } = null!;
        public int CountryId { get; set; }
        public int TerrainId { get; set; }
        public int TemperatureId { get; set; }
        public int NightLifeId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual CityNightLife NightLife { get; set; } = null!;
        public virtual CityTemperature Temperature { get; set; } = null!;
        public virtual LocType Terrain { get; set; } = null!;
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
