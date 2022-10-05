using System;
using System.Collections.Generic;

namespace FirstHolidayChat.Models
{
    public partial class HolCategory
    {
        public HolCategory()
        {
            Holidays = new HashSet<Holiday>();
        }

        public int HolTypeId { get; set; }
        public string HolType { get; set; } = null!;

        public virtual ICollection<Holiday> Holidays { get; set; }
    }
}
