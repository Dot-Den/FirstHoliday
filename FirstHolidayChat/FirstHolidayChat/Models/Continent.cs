using System;
using System.Collections.Generic;

namespace FirstHolidayChat.Models
{
    public partial class Continent
    {
        public Continent()
        {
            Countries = new HashSet<Country>();
        }

        public int ContinentId { get; set; }
        public string HolContinent { get; set; } = null!;

        public virtual ICollection<Country> Countries { get; set; }
    }
}
