using System;

namespace DS.CineLabs.Common.Models.MovieCategories
{
    public class CreateMovieCategoriesModel
    {
        public Guid MovieId { get; set; }
        public int CategoryId { get; set; }
    }
}
