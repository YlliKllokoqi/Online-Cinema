using DS.CineLabs.Application.Services.Categories;
using DS.CineLabs.Application.Services.Coupons;
using DS.CineLabs.Application.Services.MovieCategorie;
using DS.CineLabs.Application.Services.MovieDetails;
using DS.CineLabs.Application.Services.Movies;
using DS.CineLabs.Application.Services.Reviews;
using DS.CineLabs.Application.Services.Ticket;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DS.CineLabs.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMvc()
               .AddFluentValidation(fv =>
               {
                   fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
               });

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IMovieDetailsService, MovieDetailsService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMovieCategoriesService, MovieCategoriesService>();
            services.AddScoped<ICouponService, CouponService>();

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
