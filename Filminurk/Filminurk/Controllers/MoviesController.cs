using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Filminurk.model.Domain;
using Filminurk.Models.Movies;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
    public class MoviesController : Controller
    {
        
        private readonly FilminurkTarpe24Context _context;
        private readonly IMovieServices _movieServices;
        public MoviesController
            (
            FilminurkTarpe24Context context, 
            IMovieServices movieServices
            )
        {
            _context = context;
            _movieServices = movieServices;
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
        [HttpGet]
        public IActionResult Create()
        {
            MoviesCreateViewModel result = new();
            return View("Create", result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(MoviesCreateViewModel vm)
        {
            var dto = new MoviesDTO()
            {
                ID = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                FirstPublished = vm.FirstPublished,
                Director = vm.Director,
                Actors = vm.Actors,
                CurrentRating = (double?)vm.CurrentRating,
                LastWatched = vm.LastWatched,
                DurationInMinutes = vm.DurationInMinutes,
                PeopleWatched = vm.PeopleWatched
            };
            var result = await _movieServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
