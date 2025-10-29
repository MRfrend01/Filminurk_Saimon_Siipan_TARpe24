using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Filminurk.Models.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filminurk.Controllers
{
    public class MoviesController : Controller
    {
        
        private readonly FilminurkTarpe24Context _context;
        private readonly IMovieServices _movieServices;
        private readonly IFilesServices _filesServices;
        public MoviesController
            (
            FilminurkTarpe24Context context, 
            IMovieServices movieServices,
            IFilesServices filesServices
            )
        {
            _context = context;
            _movieServices = movieServices;
            _filesServices = filesServices;
        }
        [HttpGet]
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
            MoviesCreateUpdateViewModel result = new();
            return View("CreateUpdate", result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(MoviesCreateUpdateViewModel vm)
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
                PeopleWatched = vm.PeopleWatched,
                Files = vm.Files,
                FileToApiDTOs = vm.Images
                    .Select(x => new FileToApiDTO
                    {
                        ImageID = x.ImageID,
                        Filepath = x.Filepath,
                        IsPoster = x.IsPoster,
                        MovieID = x.MovieID,
                    }).ToArray()


            };
            var result = await _movieServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> Update(MoviesCreateUpdateViewModel vm)
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
                PeopleWatched = vm.PeopleWatched,
                Files = vm.Files,
                FileToApiDTOs = vm.Images
                    .Select(x => new FileToApiDTO
                    {
                        ImageID = x.ImageID,
                        Filepath = x.Filepath,
                        MovieID = x.MovieID,
                    }).ToArray()
            };
            var result = await _movieServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var movie = await _movieServices.DetailAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            var vm = new MoviesDetailViewModel();
            vm.Id = movie.Id;
            vm.Title = movie.Title;
            vm.Description = movie.Description;
            vm.FirstPublished = movie.FirstPublished;
            vm.CurrentRating = movie.CurrentRating;
            vm.PeopleWatched = movie.PeopleWatched;
            vm.LastWatched = movie.LastWatched;
            vm.DurationInMinutes = movie.DurationInMinutes;
            vm.EntryCreatedAt = movie.EntryCreatedAt;
            vm.EntryModifiedAt = movie.EntryModifiedAt;
            vm.Director = movie.Director;
            vm.Actors = movie.Actors;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var movie = await _movieServices.DetailAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
           
            var images = await _context.FilesToApi
                .Where(x => x.MovieID == movie.Id)
                .Select(y => new ImageViewModel
                {
                    ImageID = id,
                    Filepath = y.ExistingFilepath,
                }).ToArrayAsync();

            var vm = new MoviesCreateUpdateViewModel();
            vm.Id = movie.Id;
            vm.Title = movie.Title;
            vm.Description = movie.Description;
            vm.FirstPublished = movie.FirstPublished;
            vm.CurrentRating = movie.CurrentRating;
            vm.PeopleWatched = movie.PeopleWatched;
            vm.LastWatched = movie.LastWatched;
            vm.DurationInMinutes = movie.DurationInMinutes;
            vm.EntryCreatedAt = movie.EntryCreatedAt;
            vm.EntryModifiedAt = movie.EntryModifiedAt;
            vm.Director = movie.Director;
            vm.Actors = movie.Actors;
            vm.Images.AddRange(images);

            return View("CreateUpdate", vm);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var movie = await _movieServices.DetailAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
                .Where(x => x.MovieID == movie.Id)
                .Select(y => new ImageViewModel
                {
                    ImageID = id,
                    Filepath = y.ExistingFilepath,
                }).ToArrayAsync();
            var vm = new MoviesDeleteViewModel();
            vm.Id = movie.Id;
            vm.Title = movie.Title;
            vm.Description = movie.Description;
            vm.FirstPublished = movie.FirstPublished;
            vm.CurrentRating = movie.CurrentRating;
            vm.LastWatched = movie.LastWatched;
            vm.DurationInMinutes = movie.DurationInMinutes;
            vm.PeopleWatched = movie.PeopleWatched;
            vm.EntryCreatedAt = movie.EntryCreatedAt;
            vm.EntryModifiedAt = movie.EntryModifiedAt;
            vm.Director = movie.Director;
            vm.Actors = movie.Actors;

            return View(vm);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var movie = await _movieServices.Delete(id);
            if (movie == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
