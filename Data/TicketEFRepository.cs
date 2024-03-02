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

        public List<TicketDTO> GetAll()
        {
            var tickets=_context.Tickets;
            var ticketsDTO = tickets.Select(t => new TicketDTO{
                id=t.id,
                TicketRow = t.TicketRow,
                TicketColumn = t.TicketColumn,
                price = t.price,
                scheduleTicket = t.scheduleTicket,
                userId = t.userId,
                playId = t.playId
            }).ToList();
            return ticketsDTO;
        }

        public TicketDTO GetTicket(int id)
        {
            var ticket=_context.Tickets;
            if(ticket==null){
                throw new KeyNotFoundException("Ticket not found.");
            }
            var ticketDTO = ticket.Select(t => new TicketDTO{
                id=t.id,
                TicketRow = t.TicketRow,
                TicketColumn = t.TicketColumn,
                price = t.price,
                scheduleTicket = t.scheduleTicket,
                userId = t.userId,
                playId = t.playId
            }).FirstOrDefault(t => t.id == id)!;
            return ticketDTO;
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


        public List<TicketDTO> GetTicketOfPlay(int pid){
            var ticket=_context.Tickets;
            if(ticket==null){
                throw new KeyNotFoundException("Ticket not found.");
            }
            var ticketDTO = ticket.Where(t => t.playId == pid).Select(t => new TicketDTO{
                id=t.id,
                TicketRow = t.TicketRow,
                TicketColumn = t.TicketColumn,
                price = t.price,
                scheduleTicket = t.scheduleTicket,
                userId = t.userId,
                playId = t.playId
            }).ToList();
            return ticketDTO;
        }
        public List<TicketDTO> GetTicketOfUser(int uid){
            var ticket=_context.Tickets;
            if(ticket==null){
                throw new KeyNotFoundException("Ticket not found.");
            }
            var ticketDTO = ticket.Where(t => t.userId == uid).Select(t => new TicketDTO{
                id=t.id,
                TicketRow = t.TicketRow,
                TicketColumn = t.TicketColumn,
                price = t.price,
                scheduleTicket = t.scheduleTicket,
                userId = t.userId,
                playId = t.playId
            }).ToList();
            return ticketDTO;
        }
        
    }
}