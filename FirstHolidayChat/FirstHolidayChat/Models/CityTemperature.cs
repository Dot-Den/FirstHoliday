using System;
using System.Collections.Generic;

namespace FirstHolidayChat.Models
{
    public partial class CityTemperature
    {
        public CityTemperature()
        {
            Cities = new HashSet<City>();
        }

        public int TemperatureId { get; set; }
        public string TemperatureRating { get; set; } = null!;

        public virtual ICollection<City> Cities { get; set; }
    }
}
