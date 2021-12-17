using System;

namespace DS.CineLabs.Common.Models.Movies
{
    public class UpdateMovieModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DetailsId { get; set; }
        public string MovieLink { get; set; }
    }
}
