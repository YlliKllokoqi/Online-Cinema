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
   public class ReviewRepository : IReviewRepository
    {
        private readonly CinelabsDbContext _db;
        public ReviewRepository(CinelabsDbContext db)
        {
            _db = db;
        }

        public void CreateReview(Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
        }

        public void DeleteReview(int id)
        {
            var review = _db.Reviews.FirstOrDefault(x => x.Id == id);
            _db.Reviews.Remove(review);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return await _db.Reviews
                            .Include(x=>x.Movie)
                            .ToListAsync();
        }

        public async Task<Review> GetReviewById(int id)
        {
            return await _db.Reviews.FindAsync(id);
        }

    }
}
