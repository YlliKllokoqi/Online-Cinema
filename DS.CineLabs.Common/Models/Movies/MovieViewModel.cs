using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace DS.CineLabs.Common.Models.Movies
{
    public class MovieViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public int DetailsId { get; set; }
        public string MovieLink { get; set; }
        public List<int> selectedCategories { get; set; }
        public MultiSelectList CategoryList { get; set; }
    }
}
