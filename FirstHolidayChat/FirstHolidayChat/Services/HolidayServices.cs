using FirstHolidayChat.Models;
using FirstHolidayChat.Services;
using FirstHolidayChat.Context;

namespace FirstHolidayChat.Services
{
    public class HolidayServices : IHolidayServices
    {
        FirstHolDbContext db;
        public HolidayServices(FirstHolDbContext _db)
        {
            db = _db;
        }

        public IEnumerable<HolidayViewModel> GetAllHolidayDetails()
        {
            List<HolidayViewModel> holidayDetailsList = new();

            using (FirstHolDbContext FirstHolDbContext = new())
            {
                holidayDetailsList =
                    (
                    from Holidays in FirstHolDbContext.Holidays
                    join HolCategories in FirstHolDbContext.HolCategories on Holidays.HolTypeId equals HolCategories.HolTypeId
                    join Hotels in FirstHolDbContext.Hotels on Holidays.HotelId equals Hotels.HotelId
                    join Cities in FirstHolDbContext.Cities on Hotels.CityId equals Cities.CityId
                    join Countries in FirstHolDbContext.Countries on Cities.CountryId equals Countries.CountryId
                    join Continents in FirstHolDbContext.Continents on Countries.ContinentId equals Continents.ContinentId
                    join LocTypes in FirstHolDbContext.LocTypes on Cities.TerrainId equals LocTypes.TerrainId
                    join CityTemperatures in FirstHolDbContext.CityTemperatures on Cities.TemperatureId equals CityTemperatures.TemperatureId
                    join CityNightLives in FirstHolDbContext.CityNightLives on Cities.NightLifeId equals CityNightLives.NightLifeId

                    select new HolidayViewModel
                    {
                        HolidayRef = Holidays.HolidayId,
                        HolCity = Cities.HolCity,
                        NightLifeType = CityNightLives.NightLifeType,
                        TemperatureRating = CityTemperatures.TemperatureRating,
                        HolContinent = Continents.HolContinent,
                        HolCountry = Countries.HolCountry,
                        HolType = HolCategories.HolType,
                        HolHotel = Hotels.HolHotel,
                        StarRating = Hotels.StarRating,
                        PricePerNight = Hotels.PricePerNight,
                        TerrainType = LocTypes.TerrainType
                    }).ToList();
            }

            IEnumerable<HolidayViewModel> holidayDetails = holidayDetailsList;

            return (holidayDetails);
        }

        public IEnumerable<HolidayViewModel> GetHolidaySuggestions(string terrainType, string nightLife, int starRating, string temperature, string holCategory)
        {
            //string interpolation to get temperature range -- I realised that temperature written in the database is more simple (cold mild hot), so I commented it out.
            //string[] temperatureRange = temperature.Split(" - ");
            //decimal temperatureRangeLower = decimal.Parse(temperatureRange[0]);
            //decimal temperatureRangeUpper = decimal.Parse(temperatureRange[1]);

            List<HolidayViewModel> holidayDetailsList = new();

            using (FirstHolDbContext FirstHolDbContext = new())
            {
                holidayDetailsList =
                    (
                    from Holidays in FirstHolDbContext.Holidays
                    join HolCategories in FirstHolDbContext.HolCategories on Holidays.HolTypeId equals HolCategories.HolTypeId
                    join Hotels in FirstHolDbContext.Hotels on Holidays.HotelId equals Hotels.HotelId
                    join Cities in FirstHolDbContext.Cities on Hotels.CityId equals Cities.CityId
                    join Countries in FirstHolDbContext.Countries on Cities.CountryId equals Countries.CountryId
                    join Continents in FirstHolDbContext.Continents on Countries.ContinentId equals Continents.ContinentId
                    join LocTypes in FirstHolDbContext.LocTypes on Cities.TerrainId equals LocTypes.TerrainId
                    join CityTemperatures in FirstHolDbContext.CityTemperatures on Cities.TemperatureId equals CityTemperatures.TemperatureId
                    join CityNightLives in FirstHolDbContext.CityNightLives on Cities.NightLifeId equals CityNightLives.NightLifeId
                    where LocTypes.TerrainType == terrainType
                    && CityNightLives.NightLifeType == nightLife
                    && Hotels.StarRating >= starRating
                    && CityTemperatures.TemperatureRating == temperature
                    && (holCategory != "Both" ? HolCategories.HolType == holCategory : HolCategories.HolType != "")


                    select new HolidayViewModel
                    {
                        HolidayRef = Holidays.HolidayId,
                        HolCity = Cities.HolCity,
                        NightLifeType = CityNightLives.NightLifeType,
                        TemperatureRating = CityTemperatures.TemperatureRating,
                        HolContinent = Continents.HolContinent,
                        HolCountry = Countries.HolCountry,
                        HolType = HolCategories.HolType,
                        HolHotel = Hotels.HolHotel,
                        StarRating = Hotels.StarRating,
                        PricePerNight = Hotels.PricePerNight,
                        TerrainType = LocTypes.TerrainType
                    }).ToList();
            }

            IEnumerable<HolidayViewModel> holidayDetails = holidayDetailsList;

            return holidayDetails;
        }

    }
}
