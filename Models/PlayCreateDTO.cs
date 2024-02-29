using System.ComponentModel.DataAnnotations;
namespace TeatroWeb.Models;

public class PlayCreateDTO{

    [Required]
    [StringLength(80, ErrorMessage = "El titulo debe ser más corta")]
    public string title { get; set; }

    [Required]
    [StringLength(300, ErrorMessage = "La descripción debe ser más corta")]
    public string descriptionPlay { get; set; }

    [Required]
    [StringLength(400, ErrorMessage = "La sinopsis debe ser más corta")]
    public string synopsis { get; set; }

    [StringLength(30, ErrorMessage = "La biografía debe ser más corta")]
    public string? director { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "El genero debe ser más corta")]
    public string genre { get; set; }

}