namespace Filminurk.Models.Movies
{
    public class MoviesIndexViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateOnly FirstPublished { get; set; }
        public decimal? CurrentRating { get; set; }
        //public List<UserComment> Reviews { get; set; }
        public int? DurationInMinutes { get; set; }
        public int? PeopleWatched { get; set; }
    }
}
