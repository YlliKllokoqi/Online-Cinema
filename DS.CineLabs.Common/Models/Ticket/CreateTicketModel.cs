using System;

namespace DS.CineLabs.Common.Models.Ticket
{
    public class CreateTicketModel
    {
        public string Name { get; set; }
        public Guid MovieId { get; set; }

        public long Price { get; set; }
    }
}
