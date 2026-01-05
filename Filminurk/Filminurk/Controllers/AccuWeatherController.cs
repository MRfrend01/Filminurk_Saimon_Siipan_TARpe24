using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
    public class AccuWeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
