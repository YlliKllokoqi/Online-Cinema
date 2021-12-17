using Microsoft.AspNetCore.Http;
using System;

namespace DS.CineLabs.Common.Models.MovieDetails
{
    public class CreateMovieDetailsModel
    {
        public string Movie_Name { get; set; }
        public string PhotoPath { get; set; }
        public IFormFile PhotoPathFile { get; set; }
        public string CoverPath { get; set; }
        public IFormFile CoverFile { get; set; }
       
        public DateTime Premiere { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Country { get; set; }
        public string PG { get; set; }
        public string Distributor { get; set; }
        public int Length { get; set; }
        public string Schedule { get; set; }
        public string Trailer { get; set; }
    }
}
