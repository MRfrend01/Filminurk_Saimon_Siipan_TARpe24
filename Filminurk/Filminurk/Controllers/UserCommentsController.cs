using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Filminurk.Models.UserComments;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
    public class UserCommentsController : Controller
    {
        private readonly FilminurkTarpe24Context _context;
        private readonly IUserCommentServices _userCommentServices;
        public UserCommentsController(FilminurkTarpe24Context context, IUserCommentServices userCommentServices)
        {
            _context = context;
            _userCommentServices = userCommentServices;
        }
        public IActionResult Index()
        {
            var results = _context.UserComments
                .Select(c => new UserCommentsIndexViewModel
                {
                    CommentID = c.CommentID,
                    CommentBody = c.CommentBody,
                    IsHarmful = c.IsHarmful,
                    CommentCreatedAt = c.CommentCreatedAt
                }
            );
            return NotFound();
        }
        [HttpGet]
        public IActionResult NewComment()
        {
            UserCommentsCreateViewModel newcomment = new();
            return View(newcomment);
        }
        [HttpPost, ActionName("NewComment")]
        public async Task<IActionResult> NewCommentPost(UserCommentsCreateViewModel newcommentVM)
        {
            var dto = new UserCommentDTO
            {
                CommentID = (Guid)newcommentVM.CommentID,
                CommenterUserID = newcommentVM.CommenterUserID,
                CommentBody = newcommentVM.CommentBody,
                CommentedScore = newcommentVM.CommentedCreatedAt,
                CommentCreatedAt = newcommentVM.CommentCreatedAt,
                CommentModifiedAt = newcommentVM.CommentModifiedAt,
                IsHelpful = (int)newcommentVM.IsHelpful,
                IsHarmful = (int)newcommentVM.IsHarmful,
            }; 
            var result = await _userCommentServices.NewComment(dto);
            if (result == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));


        }
    }
}
