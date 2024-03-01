namespace TeatroWeb.Models;

public class TicketDTO{
    public int id {get; set;}

    public int TicketRow {get; set;}

    public int TicketColumn {get; set;}

    public decimal price {get; set;}

    public DateTime scheduleTicket {get; set;}

    public int userId {get; set;}

    public int playId {get; set;}

}