using System;
using System.Collections.Generic;

namespace FirstHolidayChat.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int CountryId { get; set; }
        public string HolCountry { get; set; } = null!;
        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; } = null!;
        public virtual ICollection<City> Cities { get; set; }
    }
}
