using System.ComponentModel.DataAnnotations;

namespace TeatroWeb.Models;

public class UserCreateDTO
{
    [Required]  
    public string username {get; set;}

    [Required]
    public string surname {get; set;}
    [Required]
    public string passwd {get; set;}
    [Required]
    public string direction {get; set;}
    [Required]
    public string email {get; set;}

    public string? notes {get; set;}

    [Required]
    public int tlf {get; set;}

    [Required]
    public string? payment {get; set;}

}