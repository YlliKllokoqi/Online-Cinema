using AutoMapper;
using DS.CineLabs.Application.Dtos;
using DS.CineLabs.Application.Dtos.Category;
using DS.CineLabs.Application.Dtos.Coupon;
using DS.CineLabs.Application.Dtos.Movie;
using DS.CineLabs.Application.Dtos.MovieCategories;
using DS.CineLabs.Application.Dtos.MovieDetails;
using DS.CineLabs.Application.Dtos.Review;
using DS.CineLabs.Application.Dtos.Ticket;
using DS.CineLabs.Domain.Entities;

namespace DS.CineLabs.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, GetMoviesDto>().ReverseMap();
            CreateMap<Movie, CreateMovieDto>().ReverseMap();
            CreateMap<Movie, UpdateMovieDto>().ReverseMap();
            CreateMap<Review, GetReviewsDto>().ReverseMap();
            CreateMap<Review, CreateReviewDto>().ReverseMap();

            CreateMap<Category, GetCategoriesDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Ticket, GetTicketDto>().ReverseMap();
            CreateMap<Ticket, CreateTicketDto>().ReverseMap();
            CreateMap<Ticket, UpdateTicketDto>().ReverseMap();

            CreateMap<MovieDetails, GetMovieDetailsDto>().ReverseMap();
            CreateMap<MovieDetails, CreateMovieDetailsDto>().ReverseMap();
            CreateMap<MovieDetails, UpdateMovieDetailsDto>().ReverseMap();

            CreateMap<MovieCategories, GetMovieCategoriesDto>().ReverseMap();
            CreateMap<MovieCategories, CreateMovieCategoriesDto>().ReverseMap();

            CreateMap<Coupon, CreateCouponDto>().ReverseMap();
            CreateMap<Coupon, GetCouponDto>().ReverseMap();
            CreateMap<Coupon, UpdateCouponDto>().ReverseMap();
            CreateMap<GetCouponDto, UpdateCouponDto>().ReverseMap();
        }
    }
}
