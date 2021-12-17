using DS.CineLabs.Domain.Entities;
using DS.CineLabs.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DS.CineLabs.Infrastructure.Persistence.Repository
{
    public class TicketRepository : ITicketRepository
    {

        private readonly CinelabsDbContext _db;

        public void CreateTicket(Ticket ticket)
        {
            ticket.CreatedAt = DateTime.Now;
            _db.Tickets.Add(ticket);
            _db.SaveChanges();
        }

        public void DeleteTicket(int id)
        {
            var ticket = _db.Tickets.FirstOrDefault(x => x.Id == id);
            _db.Tickets.Remove(ticket);
            _db.SaveChanges();
        }

        public TicketRepository(CinelabsDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return await _db.Tickets
                           .Include(x=>x.Movie)
                           .ToListAsync();
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            return await _db.Tickets
                .Include(x => x.Movie)
                .ThenInclude(x => x.Details)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void UpdateTicket(Ticket ticket)
        {
            ticket.UpdatetAt = DateTime.Now;
            _db.Tickets.Update(ticket);
            _db.SaveChanges();
        }
    }
}
