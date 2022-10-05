using System;
using System.Collections.Generic;

namespace FirstHolidayChat.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Holidays = new HashSet<Holiday>();
        }

        public int HotelId { get; set; }
        public string HolHotel { get; set; } = null!;
        public int StarRating { get; set; }
        public decimal PricePerNight { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual ICollection<Holiday> Holidays { get; set; }
    }
}
