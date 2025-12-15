using System.ComponentModel.DataAnnotations;

namespace Filminurk.Models.UserComments
{
    public class UserCommentsCreateViewModel
    {
            public Guid? CommentID { get; set; }
            public string CommenterUserID { get; set; }
            public string CommentBody { get; set; }
            public string CommentedScore { get; set; }
            public int CommentedCreatedAt { get; set; }
            public int? IsHelpful { get; set; } //👍 kasutaja ei saa loomise ajala muuta laike
            public int IsHarmful { get; set; } //👎


            public DateTime CommentCreatedAt { get; set; }
            public DateTime CommentModifiedAt { get; set; }
            public DateTime? CommentDeletedAt { get; set; }
        }
    }


 