using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Dtos.Movie
{
    public class GetMovieDetailsDto
    {
        public int Id { get; set; }
        public string Movie_Name { get; set; }
        public string PhotoPath { get; set; }
        public DateTime Premiere { get; set; }
        public string CoverPath { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Country { get; set; }
        public string PG { get; set; }
        public string Distributor { get; set; }
        public string Length { get; set; }
        public string Schedule { get; set; }
        public string Plot { get; set; }
        public string Trailer { get; set; }
    }
}
