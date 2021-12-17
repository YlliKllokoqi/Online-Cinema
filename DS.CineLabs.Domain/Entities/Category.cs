using DS.CineLabs.Domain.Entities.Base;
using System.Collections.Generic;

namespace DS.CineLabs.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<MovieCategories> MovieCategories { get; set; }
    }
}
