using DS.CineLabs.Domain.Entities.Base;
using System;

namespace DS.CineLabs.Domain.Entities
{
    public class Review : BaseEntity
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Description { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
