using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public List<Guid>? favouriteListIDs { get; set; }
        public List<Guid>? CommentIDs { get; set; }
        public List<Guid>? avatarImageID { get; set; }
        public List<Guid>? DisplayName { get; set; }


    }
}
