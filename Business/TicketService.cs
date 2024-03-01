namespace TeatroWeb.Business;

using TeatroWeb.Models;
using TeatroWeb.Data;
using System.Collections.Generic;

public class TicketService : ITicketService{

    private readonly ITicketRepository _repository;

    public TicketService(ITicketRepository repository){
        _repository=repository;
    }

    public void AddTicket(Ticket ticket)
    {
        _repository.AddTicket(ticket);
    }

    public void DeleteTicket(int id)
    {
        _repository.DeleteTicket(id);
    }

    public List<TicketDTO> GetAll()
    {
        var tickets=_repository.GetAll();
        return tickets;
    }

    public TicketDTO GetTicket(int id)
    {
        var ticket=_repository.GetTicket(id);
        return ticket;
    }

    public void UpdateTicket(Ticket ticket)
    {
        _repository.UpdateTicket(ticket);
    }
}