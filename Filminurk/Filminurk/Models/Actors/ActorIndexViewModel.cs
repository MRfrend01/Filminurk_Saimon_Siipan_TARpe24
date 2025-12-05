using Filminurk.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace Filminurk.Models.Actors
{
    public enum ActorSpecialization
    {
        Drama,
        Comedy,
        Action,
        Horror,
        Romance,
        Documentary
    }
    public class ActorIndexViewModel
    {

        [Key]
        public Guid ActorID { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public List<string> MoviesActedFor { get; set; } = new List<string>();
        public Guid? PortraitID { get; set; }

        public ActorSpecialization? PrimarySpecialization { get; set; }
        public DateOnly? CareerStartYear { get; set; } 
        public DateOnly DateOfBirth { get; set; } 
    }
}
