using DS.CineLabs.Common.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Common.Models.Coupon
{
     public class CreateCouponModel
     {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int TicketId { get; set; }
        public string Code { get; set; }
        public GetTicketModel Ticket { get; set; }
        public bool Active { get; set; } = false;
        public string UserId { get; set; }
    }
}
