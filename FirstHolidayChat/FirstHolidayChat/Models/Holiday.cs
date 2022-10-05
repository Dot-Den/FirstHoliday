using System;
using System.Collections.Generic;

namespace FirstHolidayChat.Models
{
    public partial class Holiday
    {
        public int HolidayId { get; set; }
        public int HolTypeId { get; set; }
        public int HotelId { get; set; }

        public virtual HolCategory HolType { get; set; } = null!;
        public virtual Hotel Hotel { get; set; } = null!;
    }
}
