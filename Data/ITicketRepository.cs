using TeatroWeb.Models;

namespace TeatroWeb.Data{
    public interface ITicketRepository
    {
        void AddTicket(Ticket ticket);
        Ticket GetTicket(int id);
        void UpdateTicket (Ticket ticket);
        void DeleteTicket(int id);
        List<Ticket> GetAll();
    }
}

