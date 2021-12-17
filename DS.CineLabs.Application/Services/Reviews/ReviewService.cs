using AutoMapper;
using DS.CineLabs.Application.Dtos.Review;
using DS.CineLabs.Domain.Entities;
using DS.CineLabs.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Services.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;
        public ReviewService(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void CreateReview(CreateReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            _repository.CreateReview(review);
        }

        public void DeleteReview(int id)
        {
            _repository.DeleteReview(id);
        }

        public async Task<IEnumerable<GetReviewsDto>> GetAllReviews()
        {
            var review = await _repository.GetAllReviews();
            return _mapper.Map<IEnumerable<GetReviewsDto>>(review);
        }

        public async Task<GetReviewsDto> GetReviewById(int id)
        {
            var review = await _repository.GetReviewById(id);
            return _mapper.Map<GetReviewsDto>(review);
        }

    }
}
