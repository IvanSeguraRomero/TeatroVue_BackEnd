using System.ComponentModel.DataAnnotations;
namespace TeatroWeb.Models;

public class PlayUpdateDTO{

    [StringLength(80, ErrorMessage = "El titulo debe ser mas largo")]
    public string? title { get; set; }

    [StringLength(300, ErrorMessage = "La descripción debe ser mas larga")]
    public string? descriptionPlay { get; set; }

    [StringLength(400, ErrorMessage = "La descripción debe ser mas larga")]
    public string? synopsis { get; set; }

    [StringLength(30, ErrorMessage = "La biografía debe ser mas extensa")]
    public string? director { get; set; }

    [StringLength(30, ErrorMessage = "El genero debe ser mas extenso")]
    public string? genre { get; set; }

}