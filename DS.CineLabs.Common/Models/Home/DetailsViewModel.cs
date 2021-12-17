using DS.CineLabs.Common.Models.Coupon;
using DS.CineLabs.Common.Models.Movies;
using DS.CineLabs.Common.Models.Ticket;
using System;
using System.Collections.Generic;

namespace DS.CineLabs.Common.Models.Home
{
    public class DetailsViewModel
    {
        public IEnumerable<GetTicketModel> Ticket { get; set; }
        public GetMovieModel Movie { get; set; }
        public IEnumerable<CreateCouponModel> Coupon { get; set; }
        public IEnumerable<GetMovieModel> Movies { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Description { get; set; }
        public Guid MovieId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
