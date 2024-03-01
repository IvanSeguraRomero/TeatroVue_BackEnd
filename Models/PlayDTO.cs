namespace TeatroWeb.Models;


public class PlayDTO{
    public int id {get; set;}

    public string title {get; set;}

    public string descriptionPlay {get; set;}

    public string synopsis {get; set;}

    public string? director {get; set;}

    public string? genre {get; set;}

    public List<TicketDTO> tickets {get; set;} = new List<TicketDTO>(); 

}