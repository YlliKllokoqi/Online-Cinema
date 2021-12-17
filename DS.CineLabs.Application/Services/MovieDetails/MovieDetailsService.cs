using AutoMapper;
using DS.CineLabs.Application.Dtos.Movie;
using DS.CineLabs.Application.Dtos.MovieDetails;
using DS.CineLabs.Domain.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Services.MovieDetails
{
    public class MovieDetailsService : IMovieDetailsService
    {
        private readonly IMovieDetailsRepository movieDetailsRepository;
        private readonly IMapper imapper;
        private readonly IWebHostEnvironment _env;

        public MovieDetailsService(IMovieDetailsRepository movieDetailsRepository, IMapper imapper, IWebHostEnvironment env)
        {
            this.movieDetailsRepository = movieDetailsRepository;
            this.imapper = imapper;
            _env = env;
        }

        public void Create(CreateMovieDetailsDto createMovieDetailsDto)
        {
            string webRootPath = _env.WebRootPath;

            string upload = webRootPath + @"\images\moviedetails";
            string fileName = Guid.NewGuid().ToString();
            string fileName2 = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(createMovieDetailsDto.PhotoPathFile.FileName);
            string extension2 = Path.GetExtension(createMovieDetailsDto.CoverFile.FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
            {
                createMovieDetailsDto.PhotoPathFile.CopyTo(fileStream);
            }
            using (var fileStream2 = new FileStream(Path.Combine(upload, fileName2 + extension2), FileMode.Create))
            {
                createMovieDetailsDto.CoverFile.CopyTo(fileStream2);
            }
            createMovieDetailsDto.PhotoPath = fileName + extension;
            createMovieDetailsDto.CoverPath = fileName2 + extension2;
            var MovieDetails = imapper.Map<Domain.Entities.MovieDetails>(createMovieDetailsDto);
            movieDetailsRepository.CreateMovieDetails(MovieDetails);
        }

        public void Delete(int id)
        {
            var obj = movieDetailsRepository.GetMovieDetailsById(id);
            string upload = _env.WebRootPath + @"\images\moviedetails";

            var oldFile = Path.Combine(upload, obj.Result.PhotoPath);

            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }

            movieDetailsRepository.Delete(id);
        }

        public async Task<IEnumerable<GetMovieDetailsDto>> GetMovieDetails()
        {
            var MovieDetails = await movieDetailsRepository.GetMovieDetails();
            return imapper.Map<IEnumerable<GetMovieDetailsDto>>(MovieDetails);
        }

        public async Task<GetMovieDetailsDto> GetMovieDetailsById(int id)
        {
            var MovieDetails = await movieDetailsRepository.GetMovieDetailsById(id);
            return imapper.Map<GetMovieDetailsDto>(MovieDetails);
        }

        public void Update(UpdateMovieDetailsDto updateMovieDetailsDto)
        {
            var updatedMovieDetail = imapper.Map<Domain.Entities.MovieDetails>(updateMovieDetailsDto);
            movieDetailsRepository.Update(updatedMovieDetail);
        }
    }
}
