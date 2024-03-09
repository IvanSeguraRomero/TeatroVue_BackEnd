using System.ComponentModel.DataAnnotations;
namespace TeatroWeb.Models;

public class PlayUpdateDTO{

    [StringLength(80, ErrorMessage = "El titulo debe ser mas corto")]
    public string? title { get; set; }

    [StringLength(300, ErrorMessage = "La descripción debe ser mas corta")]
    public string? descriptionPlay { get; set; }

    [StringLength(400, ErrorMessage = "La sinopsis debe ser mas corta")]
    public string? synopsis { get; set; }

    [StringLength(300, ErrorMessage = "La biografía debe ser mas corta")]
    public string? director { get; set; }

    [StringLength(30, ErrorMessage = "El genero debe ser mas corto")]
    public string? genre { get; set; }

}