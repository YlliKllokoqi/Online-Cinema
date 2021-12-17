using DS.CineLabs.Application.Dtos.Ticket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Services.Ticket
{
    public interface ITicketService
    {
        Task<IEnumerable<GetTicketDto>> GetAllTickets();
        Task<GetTicketDto> GetTicketById(int id);
        void CreateTicket(CreateTicketDto categoryDto);
        void UpdateTicket(UpdateTicketDto categoryDto);
        void DeleteTicket(int id);
    }
}
