using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Dtos.Review
{
   public class CreateReviewDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Description { get; set; }
        public Guid MovieId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
