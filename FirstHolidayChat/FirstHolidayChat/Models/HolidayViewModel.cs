namespace FirstHolidayChat.Models
{
    public class HolidayViewModel
    {
        /* City */
        public string? HolCity { get; set; }
        /* CityNightLife */
        public string? NightLifeType { get; set; }
        /* CityTemperature */
        public string? TemperatureRating { get; set; }
        /* Continent */
        public string? HolContinent { get; set; }
        /* Country */
        public string? HolCountry { get; set; }
        /* HolCategory */
        public string? HolType { get; set; }
        /* Holiday */
        public int HolidayRef { get; set; }

        /* Hotel */
        public string? HolHotel { get; set; }
        public int StarRating { get; set; }
        public decimal PricePerNight { get; set; }

        /* LocType */
        public string? TerrainType { get; set; }

    }
}
