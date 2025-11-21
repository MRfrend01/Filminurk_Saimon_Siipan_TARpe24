using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.ApplicationServices.Services
{
    public class UserCommentServices : IUserCommentServices
    {
        private readonly FilminurkTarpe24Context _context;
        public UserCommentServices(FilminurkTarpe24Context context)
        {
             
            _context = context;   
        }

        public async Task<UserComment> NewComment(UserCommentDTO newcommentDTO)
        {
            UserComment domain = new UserComment();
            {
                domain.CommentID = Guid.NewGuid();
                domain.CommenterUserID = newcommentDTO.CommenterUserID;
                domain.CommentBody = newcommentDTO.CommentBody;
                domain.CommentedScore = (int)newcommentDTO.CommentedScore;
                domain.CommentCreatedAt = DateTime.UtcNow;
                domain.CommentModifiedAt = DateTime.UtcNow;
                domain.IsHelpful = (int)newcommentDTO.IsHelpful;
                domain.IsHarmful = newcommentDTO.IsHarmful;

                await _context.UserComments.AddAsync(domain);
                await _context.SaveChangesAsync();
                return domain;
            }

        }
    }
}
