using Filminurk.ApplicationServices.Services;
using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.ApplicationServices.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IFilesServices _filesServices;

        public MovieServices(FilminurkTARpe24Context context, IFilesServices filesServices)
        {
            _context = context;
            _filesServices = filesServices;
        }

        public async Task<Movie> Create(MoviesDTO dto)
        {
            var movie = new Movie();
            movie.Id = Guid.NewGuid();
            movie.Title = dto.Title;
            movie.Description = dto.Description;
            movie.CurrentRating = (decimal?)dto.CurrentRating;
            movie.Director = dto.Director;
            movie.FirstPublished = (DateOnly)dto.FirstPublished;
            movie.Actors = dto.Actors;
            movie.LastWatched = dto.LastWatched;
            movie.DurationInMinutes = dto.DurationInMinutes;
            movie.PeopleWatched = dto.PeopleWatched;
            movie.EntryCreatedAt = DateTime.Now;
            movie.EntryModifiedAt = DateTime.Now;
            _filesServices.FilesToApi(dto, movie);
            
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;

        }
        public async Task<Movie> DetailAsync(Guid id)
        {
            var result =  await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            return result;

        }
    
            public async Task<Movie> Update(MoviesDTO dto)
        {
            Movie movie = new Movie();

            movie.Id = (Guid)dto.ID;
            movie.Title = dto.Title;
            movie.Description = dto.Description;
            movie.CurrentRating = (decimal?)dto.CurrentRating;
            movie.PeopleWatched = dto.PeopleWatched; // minu oma
            movie.FirstPublished = (DateOnly)dto.FirstPublished;
            movie.Actors = dto.Actors;
            movie.Director = dto.Director;
            movie.DurationInMinutes = dto.DurationInMinutes;// minu oma
            movie.LastWatched = dto.LastWatched;// minu oma
            movie.EntryCreatedAt = dto.EntryCreatedAt;
            movie.EntryModifiedAt = DateTime.Now;
            _filesServices.FilesToApi(dto, movie);

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> Delete(Guid id)
        {

            var result = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);

            var images = await _context.FilesToApi
                .Where(x => x.MovieID == id)
                .Select(y => new FileToApiDTO
                {
                    ImageID = y.ImageID,
                    Filepath = y.ExistingFilepath,
                    MovieID = y.MovieID,
                }).ToArrayAsync();

            await _filesServices.RemoveImagesFromApi(images);
            _context.Movies.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }


    }
}
