namespace TeatroWeb.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class Ticket{
    [Key]
    public int id {get; set;}

    [Column(TypeName = "int")]
    public int TicketRow {get; set;}

    [Column(TypeName = "int")]
    public int TicketColumn {get; set;}

    [Column(TypeName = "decimal(6, 2)")]
    public decimal price {get; set;}

    public DateTime scheduleTicket {get; set;}

    [ForeignKey("UserId")]
    public int userId {get; set;}
    public User user {get; set;}

    [ForeignKey("PlayId")]
    public int playId {get; set;}
    public Play play {get; set;}

}