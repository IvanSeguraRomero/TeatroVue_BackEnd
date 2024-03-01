using TeatroWeb.Models;

namespace TeatroWeb.Business{
    public interface ITicketService
    {
        void AddTicket(Ticket ticket);
        TicketDTO GetTicket(int id);
        void UpdateTicket (Ticket ticket);
        void DeleteTicket(int id);
        List<TicketDTO> GetAll();
    }
}

