using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
    public class UserCommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
