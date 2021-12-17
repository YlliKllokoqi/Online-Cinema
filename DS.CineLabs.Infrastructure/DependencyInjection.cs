using DS.CineLabs.Domain.Repository;
using DS.CineLabs.Domain.Repository.Interfaces;
using DS.CineLabs.Infrastructure.Identity;
using DS.CineLabs.Infrastructure.Persistence;
using DS.CineLabs.Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DS.CineLabs.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CinelabsDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("CinelabsContext"));
            });

            services.AddIdentity<AppUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddUserManager<UserManager<AppUser>>()
                .AddEntityFrameworkStores<CinelabsDbContext>();
                

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMovieDetailsRepository, MovieDetailsRepository>();
            services.AddScoped<IMovieCategoriesRepository, MovieCategoriesRepository>();
            services.AddScoped<ICouponRepository, CouponRepository>();

            return services;
        }
    }
}
