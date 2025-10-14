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
    internal class MovieServices : IMovieServices
    {
        private readonly FilminurkTarpe24Context _context;
    
    public MovieServices(FilminurkTarpe24Context context)
        {
            _context = context;

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
            
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;

        }
        public async Task<Movie> DetailAsync(Guid id)
        {
            var result =  await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            return result;

        }
    }
}