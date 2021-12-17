using DS.CineLabs.Application.Dtos.Category;
using System;

namespace DS.CineLabs.Application.Dtos.MovieCategories
{
    public class GetMovieCategoriesDto
    {
        public int Id { get; set; }
        public Guid MovieId { get; set; }
        public GetMoviesDto Movie { get; set; }
        public int CategoryId { get; set; }
        public GetCategoriesDto Category { get; set; }
    }
}
