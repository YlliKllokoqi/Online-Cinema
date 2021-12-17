using System;

namespace DS.CineLabs.Application.Dtos.MovieCategories
{
    public class CreateMovieCategoriesDto
    {
        public Guid MovieId { get; set; }
        public int CategoryId { get; set; }
    }
}