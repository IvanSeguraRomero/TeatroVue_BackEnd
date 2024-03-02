namespace TeatroWeb.Models;
using System.ComponentModel.DataAnnotations;

public class TicketUpdateDTO{

    public int? TicketRow { get; set; }

    public int? TicketColumn { get; set; }

    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe tener hasta dos decimales.")]
    public decimal? price { get; set; }


    public DateTime? scheduleTicket { get; set; }
}