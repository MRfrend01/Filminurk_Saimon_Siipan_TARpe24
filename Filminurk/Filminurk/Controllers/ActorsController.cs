using Filminurk.Data;
using Filminurk.Data;
using Filminurk.Models.Actors;
using Filminurk.Models.Actors;
using Filminurk.Models.UserComments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Filminurk.Controllers
{
    public class ActorsController : Controller
    {
        private readonly FilminurkTarpe24Context _context;
        public ActorsController(FilminurkTarpe24Context context)
        {
            _context = context;
        }
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
            PrimarySpecialization = a.PrimarySpecialization,
            CareerStartYear = a.CareerStartYear,
            DateOfBirth = (DateOnly)a.DateOfBirth

        }
    );
    return View(result);
            }
    }
}
