using TeatroWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace TeatroWeb.Data{

    public class TicketEFRepository : ITicketRepository
    {

        private readonly TeatroBackendContext _context;

        public TicketEFRepository(TeatroBackendContext context){
            _context=context;
        }
        public void AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            SaveChanges();
        }

        public void DeleteTicket(int id)
        {
            var ticket=_context.Tickets.Find(id);
            if(ticket==null){
                throw new KeyNotFoundException("Ticket not found.");
            }
            _context.Tickets.Remove(ticket);
            SaveChanges();
        }

        public List<Ticket> GetAll()
        {
            var tickets=_context.Tickets.ToList();
            return tickets;
        }

        public Ticket GetTicket(int id)
        {
            var ticket=_context.Tickets.Find(id);
            if(ticket==null){
                throw new KeyNotFoundException("Ticket not found.");
            }
            return ticket;
        }

        public void UpdateTicket(Ticket ticket)
        {
            _context.Entry(ticket).State=EntityState.Modified;
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}