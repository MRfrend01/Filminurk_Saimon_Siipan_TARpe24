namespace Filminurk.Models.Movies
{
    public class ImageViewModel
    {
        public Guid ImageID { get; set; }

        public string? Filepath { get; set; }
        public Guid? MovieID { get; set; }
        public bool? IsPoster { get; set; }

        }
}
