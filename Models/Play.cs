namespace TeatroWeb.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Play{
    [Key]
    public int id {get; set;}

    [Column(TypeName = "nvarchar(80)")]
    public string? title {get; set;}

    [Column(TypeName = "nvarchar(300)")]
    public string descriptionPlay {get; set;}

    [Column(TypeName = "nvarchar(400)")]
    public string synopsis {get; set;}

    [Column(TypeName = "nvarchar(300)")]
    public string? director {get; set;}

    [Column(TypeName = "nvarchar(30)")]
    public string? genre {get; set;}

    public List<Ticket> tickets {get; set;} = new List<Ticket>(); 

}