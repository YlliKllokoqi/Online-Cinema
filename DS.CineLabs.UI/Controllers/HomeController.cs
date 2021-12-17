using AutoMapper;
using DS.CineLabs.Application.Dtos.Review;
using DS.CineLabs.Application.Services.Categories;
using DS.CineLabs.Application.Services.Coupons;
using DS.CineLabs.Application.Services.MovieCategorie;
using DS.CineLabs.Application.Services.Movies;
using DS.CineLabs.Application.Services.Reviews;
using DS.CineLabs.Application.Services.Ticket;
using DS.CineLabs.Common.Models.Category;
using DS.CineLabs.Common.Models.Coupon;
using DS.CineLabs.Common.Models.Home;
using DS.CineLabs.Common.Models.Movies;
using DS.CineLabs.Common.Models.Ticket;
using DS.CineLabs.Infrastructure.Identity;
using DS.CineLabs.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;
using DetailsViewModel = DS.CineLabs.Common.Models.Home.DetailsViewModel;

namespace DS.CineLabs.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IMovieCategoriesService _movieCategoriesService;
        private readonly IReviewService _reviewService;
        private readonly ITicketService _ticketService;
        private readonly ICouponService _couponService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(IMovieService movieService, IMapper mapper, ICategoryService categoryService,
            IMovieCategoriesService movieCategoriesService, IReviewService reviewService,
            ITicketService ticketService, UserManager<AppUser> userManager, ICouponService couponService)
        {
            _movieService = movieService;
            _mapper = mapper;
            _categoryService = categoryService;
            _movieCategoriesService = movieCategoriesService;
            _reviewService = reviewService;
            _ticketService = ticketService;
            _userManager = userManager;
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string Category, string search, int? page)
        {
            ViewData["Category"] = await _categoryService.GetAllCategories();

            ViewData["Search"] = search;
            HomeViewModel model = new HomeViewModel()
            {
                Movies = _mapper.Map<IEnumerable<GetMovieModel>>(await _movieService.GetAllMovies()),
                Categories = _mapper.Map<IEnumerable<GetCategoryModel>>(await _categoryService.GetAllCategories()),
                MoviesByCategory = _mapper.Map<IEnumerable<GetMovieModel>>(await _movieService.GetMoviesBySearchOrCategory(Category, search)).ToPagedList(page ?? 1, 8),
                GetComingSoonMovies = _mapper.Map<IEnumerable<GetMovieModel>>(await _movieService.GetComingSoonMovies())
            };
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var userID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserId = userID;
            var getTicket = await _ticketService.GetAllTickets();
            ViewData["Category"] = await _categoryService.GetAllCategories();
            var movie = await _movieService.GetMovieById(id);
            var coupon = await _couponService.GetAll();
            if (movie == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            DetailsViewModel model = new DetailsViewModel()
            {
                Movie = _mapper.Map<GetMovieModel>(movie),
                Ticket = _mapper.Map<IEnumerable<GetTicketModel>>(getTicket),
                Coupon = _mapper.Map<IEnumerable<CreateCouponModel>>(coupon)
            };
            int ticketId = getTicket.Where(x => x.MovieId == id).Select(x => x.Id).FirstOrDefault();

            string code = coupon.Where(x => x.UserId == userID && x.TicketId == ticketId).Select(x => x.Code).FirstOrDefault();
            ViewBag.Code = code;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> WatchMovie(Guid id)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); 
            ViewBag.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Category"] = await _categoryService.GetAllCategories();
            var movie = await _movieService.GetMovieById(id);
            var coupon = await _couponService.GetAll();
            var ticket = await _ticketService.GetAllTickets();

            ViewBag.Premiere = movie.Details.Premiere;
            if (movie == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            DetailsViewModel model = new DetailsViewModel()
            {
                Movie = _mapper.Map<GetMovieModel>(movie),
                Coupon = _mapper.Map<IEnumerable<CreateCouponModel>>(coupon),
                Ticket = _mapper.Map<IEnumerable<GetTicketModel>>(ticket)
            };

            int ticketId = ticket.Where(x => x.MovieId == id).Select(x => x.Id).FirstOrDefault();

            string code = coupon.Where(x => x.UserId == userId && x.TicketId == ticketId).Select(x => x.Code).FirstOrDefault();
            ViewBag.Code = code;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReviewModel(DetailsViewModel model)
        {
            var UserId = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            model.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByEmailAsync(UserId);
            model.FirstName = user.FirstName;
            model.CreatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                var reviews = _mapper.Map<CreateReviewDto>(model);
                _reviewService.CreateReview(reviews);
                return RedirectToAction("Details", "Home", new { @id = model.MovieId });
            }
            return View("Details/{model}");
        }
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(string sms,string from,string firstname,string lastname,string phonenumber)
        {
            if(sms != null && from != null && firstname != null &&  lastname != null)
            {
                string message = "From: " + from + "\n" +
                "First Name: " + firstname + "\n" + "Last name: " + lastname + "\n" + "Phone Number: " + phonenumber + "\n" + "Message: " + sms;
                SendEmail(message, from);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserMovies()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Category"] = await _categoryService.GetAllCategories();
            var movies = await _movieService.GetAllMovies();
            var coupon = await _couponService.GetAll();
            var ticket = await _ticketService.GetAllTickets();

            DetailsViewModel model = new DetailsViewModel()
            {
                Movies = _mapper.Map<IEnumerable<GetMovieModel>>(movies),
                Coupon = _mapper.Map<IEnumerable<CreateCouponModel>>(coupon),
                Ticket = _mapper.Map<IEnumerable<GetTicketModel>>(ticket)
            };

            var tickets = coupon.Where(x => x.UserId == userId).Select(x => x.Ticket).ToList();

            ViewBag.Tickets = tickets;
            return View(model);
        }

        public void SendEmail(string sms, string from)
        {
            string emailTo = "cinelabs01@gmail.com";
            string smtpFrom =from ;
            string smtpPass = "Cinelabs123";
            string smtpSrv = "smtp.gmail.com";
            SmtpClient SmtpServer = new SmtpClient(smtpSrv);
            var mail = new MailMessage();
            mail.From = new MailAddress(smtpFrom);
            mail.To.Add(emailTo);
            mail.Subject = "Contact";
            mail.Body = sms;
            mail.Sender = new MailAddress(smtpFrom);
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(emailTo, smtpPass);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
