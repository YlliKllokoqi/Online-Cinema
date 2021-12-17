using AutoMapper;
using DS.CineLabs.Application.Dtos.Ticket;
using DS.CineLabs.Application.Services.Coupons;
using DS.CineLabs.Application.Services.Movies;
using DS.CineLabs.Application.Services.Ticket;
using DS.CineLabs.Common.Models.Ticket;
using DS.CineLabs.UI.Controllers;
using DS.CineLabs.UI.Mappings;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DS.CineLabs.UnitTests.Controllers.Ticket
{
    public class TicketControllerTest
    {
        private readonly Mock<ITicketService> _service;
        private readonly Mock<IMovieService> _movieService;
        private readonly Mock<ICouponService> _couponService;
        private readonly TicketController _controller;
        private readonly IMapper _mapper;

        public TicketControllerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            _service = new Mock<ITicketService>();
            _movieService = new Mock<IMovieService>();
            _couponService = new Mock<ICouponService>();
            _controller = new TicketController(_service.Object, _mapper, _movieService.Object, _couponService.Object);
        }

        [Fact]
        public void GetAllTicket_View()
        {
            var result = _controller.GetAllTickets(1);
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void CreateTicket_View()
        {
            var result = _controller.CreateTicket();
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void CreateTicketModel()
        {
            var ticketModel = new CreateTicketModel
            {
                Name = "TK223",
                MovieId = System.Guid.NewGuid()
            };
            var ticket = _mapper.Map<CreateTicketDto>(ticketModel);
            _service.Setup(s => s.CreateTicket(ticket));
            var result = _controller.CreateTicketModel(ticketModel);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void CreateTicketModel_InvalidModel()
        {
            _controller.ModelState.AddModelError("error", "some error");
            var result = _controller.CreateTicketModel(model: null);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void UpdateTicket_View()
        {
            var result = _controller.UpdateTicketById(2);
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void UpdateTicketModel()
        {
            var ticketModel = new UpdateTicketModel
            {
                Name = "TK322",
                MovieId = System.Guid.NewGuid()
            };

            var ticket = _mapper.Map<UpdateTicketDto>(ticketModel);
            _service.Setup(s => s.UpdateTicket(ticket));
            var result = _controller.UpdateTicketModel(ticketModel);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void UpdateTicketModel_InvalidModel()
        {
            _controller.ModelState.AddModelError("error", "some error");
            var result = _controller.UpdateTicketModel(model: null);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DeleteTicket_OkResult()
        {
            var result = _controller.DeleteTicketByIdPost(2);
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
