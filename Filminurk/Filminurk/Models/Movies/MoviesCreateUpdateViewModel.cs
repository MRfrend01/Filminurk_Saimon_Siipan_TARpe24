namespace Filminurk.model.Domain
{
    public class MoviesCreateUpdateViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly FirstPublished { get; set; }
        public string Director { get; set; }
        public List<string>? Actors { get; set; }
        public decimal? CurrentRating { get; set; }
        //public List<UserComment> Reviews { get; set; }
        public DateTime? LastWatched { get; set; }
        public int? DurationInMinutes { get; set; }
        public int? PeopleWatched { get; set; }

        /* andmebaasi jaoks vajalikud */
        public DateTime? EntryCreatedAt { get; set; }
        public DateTime? EntryModifiedAt { get; set; }
    }
}

