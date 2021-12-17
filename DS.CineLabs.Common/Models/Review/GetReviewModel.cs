using DS.CineLabs.Common.Models.Movies;
using System;

namespace DS.CineLabs.Common.Models.Review
{
    public class GetReviewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Description { get; set; }
        public Guid MovieId { get; set; }
        public GetMovieModel Movie { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
