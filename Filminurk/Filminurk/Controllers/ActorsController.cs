using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Filminurk.Models.Actors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filminurk.Controllers
{
    public class ActorsController : Controller
    {
        private readonly FilminurkTarpe24Context _context;
        private readonly IActorServices _actorServices;

        public ActorsController(FilminurkTarpe24Context context, IActorServices actorServices)
        {
            _context = context;
            _actorServices = actorServices;
        }

        [HttpGet]



        public IActionResult Index()
        {
            var result = _context.Actors
                .Select(a => new ActorIndexViewModel
                {
                    ActorID = a.ActorID,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    NickName = a.NickName,
                    MoviesActedFor = a.MoviesActedFor,
                    PortraitID = a.PortraitID,
                    PrimarySpecialization = (ActorSpecialization?)a.PrimarySpecialization,
                    CareerStartYear = a.CareerStartYear,
                    DateOfBirth = (DateOnly)a.DateOfBirth,

                }
            );
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ActorsCreateViewModel result = new ActorsCreateViewModel();
            return View(result);
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> Create(ActorsCreateViewModel vm)
        {
            if (!ModelState.IsValid) { return NotFound(); }

            var dto = new ActorDTO()
            {
                ActorID = vm.ActorID,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                NickName = vm.NickName,
                MoviesActedFor = vm.MoviesActedFor,
                PortraitID = vm.PortraitID,
                PrimarySpecialization = vm.PrimarySpecialization,
                CareerStartYear = vm.CareerStartYear,
                DateOfBirth = vm.DateOfBirth,
            };

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.ActorID == id);
            var vm = new ActorsDeleteViewModel();
            vm.ActorID = actor.ActorID;
            vm.FirstName = actor.FirstName;
            vm.LastName = actor.LastName;
            vm.NickName = actor.NickName;
            vm.MoviesActedFor = actor.MoviesActedFor;
            vm.PortraitID = actor.PortraitID;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(Guid id, IActorServices actorServices)
        {
            var actor = await actorServices.Delete(id);
            if (actor == null) { return NotFound(); }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.ActorID == id);

            var vm = new ActorsDetailsViewModel();
            vm.ActorID = actor.ActorID;
            vm.FirstName = actor.FirstName;
            vm.LastName = actor.LastName;
            vm.NickName = actor.NickName;
            vm.MoviesActedFor = actor.MoviesActedFor;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.ActorID == id);

            var vm = new ActorsUpdateViewModel();
            vm.ActorID = actor.ActorID;
            vm.FirstName = actor.FirstName;
            vm.LastName = actor.LastName;
            vm.NickName = actor.NickName;
            vm.MoviesActedFor = actor.MoviesActedFor;
            vm.PortraitID = actor.PortraitID;
            vm.PrimarySpecialization = (ActorSpecialization?)actor.PrimarySpecialization;
            vm.CareerStartYear = actor.CareerStartYear;
            vm.DateOfBirth = (DateOnly)actor.DateOfBirth;


            return View(vm);
        }
        [HttpPost, ActionName("Update")]
        public async Task<IActionResult> Update(ActorsUpdateViewModel vm)
        {
            if (!ModelState.IsValid) { return NotFound(); }
            var dto = new ActorDTO()
            {
                ActorID = vm.ActorID,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                NickName = vm.NickName,
                MoviesActedFor = vm.MoviesActedFor,
                PortraitID = vm.PortraitID,
                PrimarySpecialization = vm.PrimarySpecialization,
                CareerStartYear = vm.CareerStartYear,
                DateOfBirth = vm.DateOfBirth,
            };
            var actor = await _actorServices.Update(dto);
            if (actor == null) { return NotFound(); }
            return RedirectToAction(nameof(Index));
        }
    }
}