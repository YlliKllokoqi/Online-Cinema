using DS.CineLabs.Common.Models.Category;
using DS.CineLabs.Common.Models.Movies;
using System.Collections.Generic;
using X.PagedList;

namespace DS.CineLabs.Common.Models.Home
{
    public class HomeViewModel
    {
        public IEnumerable<GetMovieModel> Movies { get; set; }
        public IEnumerable<GetCategoryModel> Categories { get; set; }
        public IPagedList<GetMovieModel> MoviesByCategory { get; set; }
        public IEnumerable<GetMovieModel> SearchMovie { get; set; }
        public IEnumerable<GetMovieModel> GetComingSoonMovies { get; set; }
    }
}
