using System;
using System.Collections.Generic;

namespace DS.CineLabs.Domain.Entities
{
    public class Movie 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DetailsId { get; set; }
        public string MovieLink { get; set; }
        public virtual MovieDetails Details { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<MovieCategories> MovieCategories { get; set; }
    }
}
