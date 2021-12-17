using DS.CineLabs.Application.Services.Coupons;
using DS.CineLabs.Application.Services.Movies;
using DS.CineLabs.Application.Services.Reviews;
using DS.CineLabs.Application.Services.Ticket;
using DS.CineLabs.Infrastructure.Identity;
using DS.CineLabs.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DS.CineLabs.UI.Controllers
{
    [Authorize(Roles = RolesModel.AdminRole)]
    public class AdminController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IReviewService _reviewService;
        private readonly ITicketService _ticketService;
        private readonly ICouponService _couponService;
        private readonly UserManager<AppUser> _userManager;
        public AdminController(IMovieService movieService, IReviewService reviewService, ITicketService ticketService, UserManager<AppUser> userManager,ICouponService couponService)
        {
            _movieService = movieService;
            _reviewService = reviewService;
            _ticketService = ticketService;
            _userManager = userManager;
            _couponService = couponService;
        }
        public async Task<IActionResult> Dashboard()
        {
            var movies = await _movieService.GetAllMovies();
            var reviews = await _reviewService.GetAllReviews();
            var tickets = await _ticketService.GetAllTickets();
            var coupons = await _couponService.GetAll();
            var users = await _userManager.Users.ToListAsync();
            ViewBag.Movies = movies.Count();
            ViewBag.Reviews = reviews.Count();
            ViewBag.Coupons = coupons.Count();
            ViewBag.Users = users.Count();

            var UserId = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(UserId);
            ViewBag.FirstName = user.FirstName;
            
            return View();

        }
    }
}
