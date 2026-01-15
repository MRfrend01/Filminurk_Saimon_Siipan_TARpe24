using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.Domain
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
    public class Actors
    {
        public Guid ActorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NickName { get; set; }
        public List<string>? MoviesActedFor { get; set; }
        public Guid PortraitID { get; set; }

        public ActorSpecialization? PrimarySpecialization { get; set; }
        public DateOnly? CareerStartYear { get; set; }
        public DateOnly? DateOfBirth { get; set; }
    }
}
