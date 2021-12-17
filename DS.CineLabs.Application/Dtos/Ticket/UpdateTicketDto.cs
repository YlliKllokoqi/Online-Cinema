using System;

namespace DS.CineLabs.Application.Dtos.Ticket
{
    public class UpdateTicketDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid MovieId { get; set; }
        public long Price { get; set; }
        public int TicketDetailsId { get; set; }
    }
}
