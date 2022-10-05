using System;
using System.Collections.Generic;

namespace FirstHolidayChat.Models
{
    public partial class CityNightLife
    {
        public CityNightLife()
        {
            Cities = new HashSet<City>();
        }

        public int NightLifeId { get; set; }
        public string NightLifeType { get; set; } = null!;

        public virtual ICollection<City> Cities { get; set; }
    }
}
