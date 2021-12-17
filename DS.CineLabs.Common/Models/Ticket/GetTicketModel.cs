using DS.CineLabs.Common.Models.Movies;
using System;

namespace DS.CineLabs.Common.Models.Ticket
{
    public class GetTicketModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid MovieId { get; set; }
        public long Price { get; set; }
        public GetMovieModel Movie { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
