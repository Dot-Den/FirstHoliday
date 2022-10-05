using System;
using System.Collections.Generic;

namespace FirstHolidayChat.Models
{
    public partial class LocType
    {
        public LocType()
        {
            Cities = new HashSet<City>();
        }

        public int TerrainId { get; set; }
        public string TerrainType { get; set; } = null!;

        public virtual ICollection<City> Cities { get; set; }
    }
}
