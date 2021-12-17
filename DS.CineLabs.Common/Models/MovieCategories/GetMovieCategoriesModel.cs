using DS.CineLabs.Common.Models.Category;
using DS.CineLabs.Common.Models.Movies;
using System;
using System.Collections.Generic;

namespace DS.CineLabs.Common.Models.MovieCategories
{
    public class GetMovieCategoriesModel
    {
        public int Id { get; set; }
        public Guid MovieId { get; set; }
        public GetMovieModel Movie { get; set; }
        public int CategoryId { get; set; }
        public GetCategoryModel Category { get; set; }
    }
}
