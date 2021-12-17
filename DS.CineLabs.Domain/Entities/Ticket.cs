using DS.CineLabs.Domain.Entities.Base;
using System;

namespace DS.CineLabs.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public string Name { get; set; }
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public long Price { get; set; }
    }
}
