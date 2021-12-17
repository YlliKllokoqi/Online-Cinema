using DS.CineLabs.Domain.Entities;
using DS.CineLabs.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DS.CineLabs.Infrastructure.Persistence.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinelabsDbContext _db;
        public MovieRepository(CinelabsDbContext db)
        {
            _db = db;
        }
        public void CreateMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public void DeleteMovie(Guid id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _db.Movies
                .Include(x => x.MovieCategories)
                .ThenInclude(x => x.Category)
                .Include(x => x.Details)
                .Include(x => x.Reviews)
                .OrderByDescending(x=> x.DetailsId)
                .ToListAsync();
        }

        public async Task<Movie> GetMovieById(Guid id)
        {
            return await _db.Movies
                .Include(x => x.Details)
                .Include(x => x.MovieCategories)
                .ThenInclude(x => x.Category)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesBySearchOrCategory(string category, string search)
        {
            if (category != null)
            {
                return await _db.MovieCategories.Where(x => x.Category.Name == category)
                .Select(x => x.Movie).ToListAsync();
            }
            else if (search != null)
            {
                return await _db.Movies.Where(x => x.Name.Contains(search)).ToListAsync();
            }
            else
            {
                return await _db.Movies.Where(x => x.Details.Premiere.Date < DateTime.Now.Date)
                    .OrderByDescending(x=>x.DetailsId)
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<Movie>> GetComingSoonMovies()
        {
            return await _db.Movies.Where(x => x.Details.Premiere > DateTime.Now).ToListAsync();
        }

        public void UpdateMovie(Movie movie)
        {
            _db.Movies.Update(movie);
            _db.SaveChanges();
        }
    }
}
