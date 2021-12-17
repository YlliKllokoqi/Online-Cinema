using DS.CineLabs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Domain.Repository.Interfaces
{
     public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviews();
        Task<Review> GetReviewById(int id);
        void CreateReview(Review review);
        void DeleteReview(int id);
    }
}
