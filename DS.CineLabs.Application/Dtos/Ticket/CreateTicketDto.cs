using System;

namespace DS.CineLabs.Application.Dtos.Ticket
{
    public class CreateTicketDto
    {
        public string Name { get; set; }
        public Guid MovieId { get; set; }
        public int TicketDetailsId { get; set; }
        public long Price { get; set; }
    }
}
