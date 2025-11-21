using Filminurk.Core.Domain;

namespace Filminurk.Models.Actors
{
    public class ActorsDetailsViewModel
    {
        public ActorsDetailsViewModel() { }
        public Guid ActorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NickName { get; set; }
        public List<string>? MoviesActedFor { get; set; }
        public List<string>? AwardsWon { get; set; }
        public Guid PortraitID { get; set; }
        public ActorSpecialization? PrimarySpecialization { get; set; }
        public DateOnly? CareerStartYear { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public DateTime? DateOfBirthDate { get;
            set;
        }

    }
}
