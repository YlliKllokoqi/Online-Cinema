using DS.CineLabs.Domain.Entities;
using DS.CineLabs.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DS.CineLabs.Infrastructure.Persistence.Repository
{
    public class MovieCategoriesRepository : IMovieCategoriesRepository
    {
        private readonly CinelabsDbContext _db;
        public MovieCategoriesRepository(CinelabsDbContext db)
        {
            _db = db;
        }
        public void Create(MovieCategories movieCategories)
        {
            _db.MovieCategories.Add(movieCategories);
            _db.SaveChanges();
        }
        
        public async Task<IEnumerable<MovieCategories>> GetAll()
        {
            return await _db.MovieCategories.ToListAsync();
        }
    }
}
