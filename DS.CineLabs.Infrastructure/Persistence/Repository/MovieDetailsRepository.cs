using DS.CineLabs.Domain.Entities;
using DS.CineLabs.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Infrastructure.Persistence.Repository
{
    public class MovieDetailsRepository : IMovieDetailsRepository
    {
        private readonly CinelabsDbContext dbContext;

        public MovieDetailsRepository(CinelabsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateMovieDetails(MovieDetails movieDetails)
        {
            dbContext.Add(movieDetails);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletedMovieDetail = dbContext.MovieDetails.FirstOrDefault(m => m.Id == id);
            dbContext.MovieDetails.Remove(deletedMovieDetail);
            dbContext.SaveChanges();
        }

        public async Task<IEnumerable<MovieDetails>> GetMovieDetails()
        {
            return await dbContext.MovieDetails
                .OrderByDescending(x=>x.Id)
                .ToListAsync();
        }

        public async Task<MovieDetails> GetMovieDetailsById(int id)
        {
            return await dbContext.MovieDetails.FindAsync(id);
        }

        public void Update(MovieDetails movieDetails)
        {
            dbContext.MovieDetails.Update(movieDetails);
            dbContext.SaveChanges();
        }
    }
}
