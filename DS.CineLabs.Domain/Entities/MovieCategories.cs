using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Domain.Entities
{
    public class MovieCategories
    {
        public int Id { get; set; }
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
