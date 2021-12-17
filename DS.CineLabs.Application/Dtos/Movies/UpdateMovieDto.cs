using System;

namespace DS.CineLabs.Application.Dtos.Movie
{
    public class UpdateMovieDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DetailsId { get; set; }
        public string MovieLink { get; set; }
    }
}
