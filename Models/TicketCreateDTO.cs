namespace TeatroWeb.Models;
using System.ComponentModel.DataAnnotations;

public class TicketCreateDTO{
    
    [Required]
    public int TicketRow { get; set; }

    [Required]
    public int TicketColumn { get; set; }

    [Required]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe tener hasta dos decimales.")]
    public decimal price { get; set; }

    [Required]
    public DateTime scheduleTicket { get; set; }

    [Required]
    public int userId { get; set; }
    [Required]
    public int playId { get; set; }
}