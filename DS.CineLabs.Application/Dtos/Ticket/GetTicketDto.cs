using System;

namespace DS.CineLabs.Application.Dtos.Ticket
{
    public class GetTicketDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid MovieId { get; set; }
        public GetMoviesDto Movie { get; set; }
        public DateTime CreatedAt { get; set; }
        public long Price { get; set; }
    }
}
