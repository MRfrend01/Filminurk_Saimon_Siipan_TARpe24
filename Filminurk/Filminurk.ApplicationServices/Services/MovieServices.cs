using Filminurk.ApplicationServices.Services;
using Filminurk.Data;
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
    }
    public Movieservices(FilminurkTarpe24Context context)
    {
        _context = context;
        
    }
    
    public async Task<Movie> 
}

