using Microsoft.AspNetCore.Mvc;
using FirstHolidayChat.Context;
using FirstHolidayChat.Services;
using FirstHolidayChat.Models;

namespace FirstHolidayChat.Controllers
{
    public class HolidayController : Controller
    {
        IHolidayServices ihs;

        public HolidayController(IHolidayServices _ihs)
        {
            ihs = _ihs;
        }

        public IActionResult Index()
        {
            IEnumerable<HolidayViewModel> holidays = ihs.GetAllHolidayDetails();

            return View(holidays);
        }

        public IActionResult AllHolidayDetails()
        {
            IEnumerable<HolidayViewModel> holidays = ihs.GetAllHolidayDetails();

            return View(holidays);
        }

        public IActionResult holidaySuggestions(string terrainType, string nightLife, int starRating, string temperature, string holCategory)
        {
            IEnumerable<HolidayViewModel> holidays = ihs.GetHolidaySuggestions(terrainType, nightLife, starRating, temperature, holCategory);

            return View(holidays);
        }

    }

}
