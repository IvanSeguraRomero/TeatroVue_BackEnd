namespace TeatroWeb.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class User
{
    [Key]
    public int id {get; set;}

    [Column(TypeName = "nvarchar(30)")]
    public string? username {get; set;}

    [Column(TypeName = "nvarchar(80)")]
    public string? surname {get; set;}

    [Column(TypeName = "nvarchar(30)")]
    public string? passwd {get; set;}

    [Column(TypeName = "nvarchar(100)")]
    public string? direction {get; set;}

    [Column(TypeName = "nvarchar(100)")]
    public string email {get; set;}

    [Column(TypeName = "nvarchar(100)")]
    public string notes {get; set;}

    [Column(TypeName = "int")]
    public int tlf {get; set;}

    [Column(TypeName = "nvarchar(100)")]
    public string? payment {get; set;}

    public List<Ticket> tickets {get; set;} = new List<Ticket>();


}
