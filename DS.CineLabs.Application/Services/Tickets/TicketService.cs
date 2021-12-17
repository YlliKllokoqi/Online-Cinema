using AutoMapper;
using DS.CineLabs.Application.Dtos.Ticket;
using DS.CineLabs.Domain.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Stripe;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace DS.CineLabs.Application.Services.Ticket
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public TicketService(ITicketRepository repository, IMapper mapper, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _accessor = accessor;
        }

        public void CreateTicket(CreateTicketDto ticketDto)
        {
            var ticket = _mapper.Map<DS.CineLabs.Domain.Entities.Ticket>(ticketDto);
            _repository.CreateTicket(ticket);
        }

        public void DeleteTicket(int id)
        {
            _repository.DeleteTicket(id);
        }

        public void UpdateTicket(UpdateTicketDto ticketDto)
        {
            var updateTicket = _mapper.Map<DS.CineLabs.Domain.Entities.Ticket>(ticketDto);
            _repository.UpdateTicket(updateTicket);
        }

        public async Task<IEnumerable<GetTicketDto>> GetAllTickets()
        {
            var tickets = await _repository.GetAllTickets();
            return _mapper.Map<IEnumerable<GetTicketDto>>(tickets);
        }

        public async Task<GetTicketDto> GetTicketById(int id)
        {
            var tickets = await _repository.GetTicketById(id);
            return _mapper.Map<GetTicketDto>(tickets);
        }
    }
}
