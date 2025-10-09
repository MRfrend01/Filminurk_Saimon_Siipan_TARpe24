using Filminurk.Data;
using Filminurk.Models.Movies;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
    public class MoviesController : Controller
    {
        
        private readonly FilminurkTarpe24Context _context;
        public MoviesController(FilminurkTarpe24Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var results = _context.Movies.Select(X => new MoviesIndexViewModel
            {
                Id = X.Id,
                Title = X.Title,
                FirstPublished = X.FirstPublished,
                CurrentRating = X.CurrentRating,
                DurationInMinutes = X.DurationInMinutes,
                PeopleWatched = X.PeopleWatched
            });
            return View(results);
        }
    }
}
