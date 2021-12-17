using DS.CineLabs.Application.Dtos.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Services.Reviews
{
     public interface IReviewService
    {
        Task<IEnumerable<GetReviewsDto>> GetAllReviews();
        Task<GetReviewsDto> GetReviewById(int id);
        void CreateReview(CreateReviewDto reviewDto);
        void DeleteReview(int id);
    }
}
