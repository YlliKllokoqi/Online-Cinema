using DS.CineLabs.Common.Models.MovieCategories;
using DS.CineLabs.Common.Models.MovieDetails;
using DS.CineLabs.Common.Models.Review;
using System;
using System.Collections.Generic;

namespace DS.CineLabs.Common.Models.Movies
{
    public class GetMovieModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DetailsId { get; set; }
        public string MovieLink { get; set; }
        public virtual GetMovieDetailsModel Details { get; set; }
        public ICollection<GetMovieCategoriesModel> MovieCategories { get; set; }
        public ICollection<GetReviewModel> Reviews { get; set; }
    }
}
