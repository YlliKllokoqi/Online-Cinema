using System;

namespace DS.CineLabs.Domain.Entities
{
    public class Coupon
    {
        public Guid Id { get; set; }
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }
    }
}
