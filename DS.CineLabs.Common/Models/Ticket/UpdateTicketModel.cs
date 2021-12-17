using System;

namespace DS.CineLabs.Common.Models.Ticket
{
    public class UpdateTicketModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Guid MovieId { get; set; }
        public long Price { get; set; }
    }
}
