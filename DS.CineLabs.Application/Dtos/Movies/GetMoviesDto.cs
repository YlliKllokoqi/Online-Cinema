using DS.CineLabs.Application.Dtos.Movie;
using DS.CineLabs.Application.Dtos.MovieCategories;
using DS.CineLabs.Application.Dtos.Review;
using System;
using System.Collections.Generic;

namespace DS.CineLabs.Application.Dtos
{
    public class GetMoviesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DetailsId { get; set; }
        public string MovieLink { get; set; }
        public virtual GetMovieDetailsDto Details { get; set; }
        public ICollection<GetMovieCategoriesDto> MovieCategories { get; set; }
        public ICollection<GetReviewsDto> Reviews { get; set; }
    }
}
