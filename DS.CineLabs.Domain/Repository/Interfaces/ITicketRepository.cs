using DS.CineLabs.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.CineLabs.Domain.Repository.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<Ticket> GetTicketById(int id);
        void CreateTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(int id);
    }
}
