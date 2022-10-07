using FirstHolidayChat.Models;

namespace FirstHolidayChat.Services
{
    public interface IHolidayServices
    {
        public IEnumerable<HolidayViewModel> GetAllHolidayDetails();
        public IEnumerable<HolidayViewModel> GetHolidaySuggestions(string terrainType, string nightLife, int starRating, string temperature, string holCategory);
    }
}
