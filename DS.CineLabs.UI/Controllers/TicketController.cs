using AutoMapper;
using DS.CineLabs.Application.Dtos.Coupon;
using DS.CineLabs.Application.Dtos.Ticket;
using DS.CineLabs.Application.Services.Coupons;
using DS.CineLabs.Application.Services.Movies;
using DS.CineLabs.Application.Services.Ticket;
using DS.CineLabs.Common.Models.Coupon;
using DS.CineLabs.Common.Models.Movies;
using DS.CineLabs.Common.Models.Ticket;
using DS.CineLabs.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace DS.CineLabs.UI.Controllers
{
    public class TicketController : Controller
    {

        private readonly ITicketService _service;
        private readonly IMapper _mapper;
        private readonly IMovieService _movieservice;
        private readonly ICouponService _couponService;


        public TicketController(ITicketService service, IMapper mapper, IMovieService movieservice, ICouponService couponService)
        {
            _service = service;
            _mapper = mapper;
            _movieservice = movieservice;
            _couponService = couponService;
        }

        [Authorize(Roles = RolesModel.AdminRole)]
        [HttpGet]
        [Route("Ticket")]
        public async Task<IActionResult> GetAllTickets(int? page)
        {
            var ticket = await _service.GetAllTickets();
            var model = _mapper.Map<IEnumerable<GetTicketModel>>(ticket);
            return View(model.ToPagedList(page ?? 1, 5));
        }

        [Authorize(Roles = RolesModel.AdminRole)]
        [HttpGet]
        [Route("Ticket/Create")]
        public async Task<IActionResult> CreateTicket()
        {
            var movieList = await _movieservice.GetAllMovies();

            //   var movieTickets = ticket.Where(x => x.MovieId == movie.Id).Select(x => x.Movie).ToList();

            ViewBag.Movies = new SelectList(movieList, "Id", "Name");
            return View(new CreateTicketModel());
        }

        [Authorize(Roles = RolesModel.AdminRole)]
        [HttpPost]
        public IActionResult CreateTicketModel(CreateTicketModel model)
        {
            if (ModelState.IsValid)
            {
                var ticket = _mapper.Map<CreateTicketDto>(model);
                _service.CreateTicket(ticket);
                return RedirectToAction("GetAllTickets");
            }
            return View("CreateTicket");
        }

        [Authorize(Roles = RolesModel.AdminRole)]
        [HttpGet]
        [Route("Ticket/Delete/{id}")]
        public async Task<IActionResult> DeleteTicketById(int id)
        {
            var ticket = await _service.GetTicketById(id);
            var modelToReturn = _mapper.Map<GetTicketModel>(ticket);
            return View(modelToReturn);
        }

        [Authorize(Roles = RolesModel.AdminRole)]
        [HttpPost]
        public IActionResult DeleteTicketByIdPost(int id)
        {
            _service.DeleteTicket(id);
            return RedirectToAction("GetAllTickets");
        }

        [Authorize(Roles = RolesModel.AdminRole)]
        [HttpGet]
        [Route("Ticket/Edit/{id}")]
        public async Task<IActionResult> UpdateTicketById(int id)
        {
            var movieList = await _movieservice.GetAllMovies();
            ViewBag.Movies = new SelectList(movieList, "Id", "Name");
            var ticket = await _service.GetTicketById(id);
            var model = _mapper.Map<UpdateTicketModel>(ticket);
            return View(model);
        }

        [Authorize(Roles = RolesModel.AdminRole)]
        [HttpPost]
        public IActionResult UpdateTicketModel(UpdateTicketModel model)
        {
            if (ModelState.IsValid)
            {
                var updated = _mapper.Map<UpdateTicketDto>(model);
                _service.UpdateTicket(updated);
                return RedirectToAction("GetAllTickets");
            }
            return View("UpdateTicketById");
        }

        [Authorize(Roles = RolesModel.CustomerRole)]
        [HttpGet]
        public async Task<IActionResult> TicketDetails(int id)
        {
            var ticket = await _service.GetTicketById(id);

            if (ticket == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            TicketViewModel ticketDetails = new TicketViewModel
            {
                Ticket = _mapper.Map<GetTicketModel>(await _service.GetTicketById(id))
            };

            return View(ticketDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Payment(Guid movieId)
        {
            movieId = (Guid)TempData["ID"];
            var model = await _movieservice.GetMovieById(movieId);
            var map = _mapper.Map<GetMovieModel>(model);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(string stripeToken, int id, Guid movieId)
        {
            TempData["ID"] = movieId;
            var tk = await _service.GetTicketById(id);
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var customers = new CustomerService();
            var charges = new ChargeService();

            var coupon = new CreateCouponModel
            {
                TicketId = id,
                Code = CreateCoupon(),
                UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            var createcoupon = _mapper.Map<CreateCouponDto>(coupon);
            _couponService.CreateCoupon(createcoupon);

            var Getcoupon = await _couponService.GetCouponById(coupon.Id);

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = userEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = tk.Price * 100,
                Description = "Ticket Payment",
                Currency = "eur",
                Customer = customer.Id
            });
            return RedirectToAction("Payment", new { Id = movieId });
        }

        private static Random coupon = new Random();
        public static string CreateCoupon()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
            .Select(s => s[coupon.Next(s.Length)]).ToArray());
        }

    }
}
