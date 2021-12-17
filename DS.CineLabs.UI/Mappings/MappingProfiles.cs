using AutoMapper;
using DS.CineLabs.Application.Dtos;
using DS.CineLabs.Application.Dtos.Category;
using DS.CineLabs.Application.Dtos.Coupon;
using DS.CineLabs.Application.Dtos.Movie;
using DS.CineLabs.Application.Dtos.MovieCategories;
using DS.CineLabs.Application.Dtos.MovieDetails;
using DS.CineLabs.Application.Dtos.Review;
using DS.CineLabs.Application.Dtos.Ticket;
using DS.CineLabs.Common.Models.Category;
using DS.CineLabs.Common.Models.Coupon;
using DS.CineLabs.Common.Models.Home;
using DS.CineLabs.Common.Models.MovieCategories;
using DS.CineLabs.Common.Models.MovieDetails;
using DS.CineLabs.Common.Models.Movies;
using DS.CineLabs.Common.Models.Review;
using DS.CineLabs.Common.Models.Ticket;

namespace DS.CineLabs.UI.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<GetReviewsDto, GetReviewModel>().ReverseMap();

            CreateMap<GetCategoriesDto, GetCategoryModel>().ReverseMap();
            CreateMap<CreateCategoryDto, CreateCategoryModel>().ReverseMap();
            CreateMap<GetCategoriesDto, UpdateCategoryModel>().ReverseMap();
            CreateMap<UpdateCategoryDto, UpdateCategoryModel>().ReverseMap();


            CreateMap<GetMoviesDto, GetMovieModel>().ReverseMap();
            CreateMap<CreateMovieDto, MovieViewModel>().ReverseMap();
            CreateMap<GetMoviesDto, UpdateMovieModel>().ReverseMap();
            CreateMap<UpdateMovieDto, UpdateMovieModel>().ReverseMap();


            CreateMap<GetMovieDetailsDto, GetMovieDetailsModel>().ReverseMap();
            CreateMap<CreateMovieDetailsDto, CreateMovieDetailsModel>().ReverseMap();
            CreateMap<GetMovieDetailsDto, UpdateMovieDetailsModel>().ReverseMap();
            CreateMap<UpdateMovieDetailsDto, UpdateMovieDetailsModel>().ReverseMap();


            CreateMap<GetTicketDto, GetTicketModel>().ReverseMap();
            CreateMap<CreateTicketDto, CreateTicketModel>().ReverseMap();
            CreateMap<GetTicketDto, UpdateTicketModel>().ReverseMap();
            CreateMap<UpdateTicketDto, UpdateTicketModel>().ReverseMap();

            CreateMap<GetMovieCategoriesDto, GetMovieCategoriesModel>().ReverseMap();
            CreateMap<CreateMovieCategoriesDto, CreateMovieCategoriesModel>().ReverseMap();

            CreateMap<DetailsViewModel, CreateReviewDto>().ReverseMap();

            CreateMap<CreateCouponDto, CreateCouponModel>().ReverseMap();
            CreateMap<GetCouponDto, CreateCouponModel>().ReverseMap();
            CreateMap<UpdateCouponDto, UpdateCouponModel>().ReverseMap();

        }
    }
}
