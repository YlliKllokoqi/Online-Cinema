using DS.CineLabs.Domain.Entities;
using DS.CineLabs.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DS.CineLabs.Infrastructure.Persistence
{
    public class CinelabsDbContext : IdentityDbContext
    {
        public CinelabsDbContext(DbContextOptions<CinelabsDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDetails> MovieDetails { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<MovieCategories> MovieCategories { get; set; }
        public DbSet<Coupon> Coupon { get; set; }

    }
}
