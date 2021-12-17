using System;

namespace DS.CineLabs.Common.Models.Coupon
{
    public class UpdateCouponModel
    {
        public Guid Id { get; set; }
        public int TicketId { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }
    }
}
