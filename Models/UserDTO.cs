namespace TeatroWeb.Models;

public class UserDTO
{
    public int id {get; set;}

    public string username {get; set;}

    public string surname {get; set;}

    public string passwd {get; set;}

    public string? direction {get; set;}
    public string email {get; set;}

    public string? notes {get; set;}

    public int tlf {get; set;}

    public string? payment {get; set;}

    public List<TicketDTO> tickets {get; set;} = new List<TicketDTO>();


}
