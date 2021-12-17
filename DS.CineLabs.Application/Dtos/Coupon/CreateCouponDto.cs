using DS.CineLabs.Application.Dtos.Ticket;
using System;

namespace DS.CineLabs.Application.Dtos.Coupon
{
    public class CreateCouponDto
    {
        public Guid Id { get; set; }
        public int TicketId { get; set; }
        public string Code { get; set; }
        public GetTicketDto Ticket { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }
    }
}
