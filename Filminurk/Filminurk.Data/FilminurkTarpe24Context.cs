using Filminurk.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Data
{
    public class FilminurkTarpe24Context : DbContext
    {
        public FilminurkTarpe24Context(DbContextOptions<FilminurkTarpe24Context> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<FileToApi> FilesToApi { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<Actor> Actors { get; set; } 
        public DbSet<IdentityRole> identityRoles { get; set; }

    }
}
