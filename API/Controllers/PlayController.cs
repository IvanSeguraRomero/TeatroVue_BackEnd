using TeatroWeb.Models;
using TeatroWeb.Business;
using Microsoft.AspNetCore.Mvc;
using TeatroWeb.Data;
using Microsoft.Extensions.Logging;

namespace TeatroWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayController : ControllerBase
{
    private readonly ILogger<PlayController> _logger;
    private readonly IPlayService? playService;
    public PlayController(ILogger<PlayController> logger, IPlayService? _playService)
    {
        _logger = logger;
        playService=_playService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<PlayDTO>> GetAll(){
        try{
            return playService.GetAll();
        }catch (Exception ex)
        {
            LogError(ex, $"Error al obtener la información de las obras");
            return StatusCode(500, "Error interno del servidor");
        }
    }


    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<PlayDTO> Get(int id)
    {
        try
        {
            var play = playService.GetPlayDTO(id);

            if (play == null)
            {
                LogError(new Exception("No se encontró la obra"), $"Error al obtener la información de la obra con ID {id}");
                
                return NotFound();
            }

            return play;
        }
        catch (Exception ex)
        {
            LogError(ex, $"Error al obtener la información de la obra con ID {id}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // POST action
    [HttpPost]
    public IActionResult Create([FromBody] PlayCreateDTO playDto)
    {
        try{            
        if (!ModelState.IsValid)
        {
            LogError(new Exception("No se pudo crear la obra"), $"Error al almacenar la información de la obra {ModelState}");
            return BadRequest(ModelState);
        }

        var play = new Play
        {
            title = playDto.title,
            descriptionPlay = playDto.descriptionPlay,
            synopsis = playDto.synopsis,
            director = playDto.director,
            genre = playDto.genre
        };

        playService.AddPlay(play);

        // Devolver la respuesta CreatedAtAction con el nuevo DTO
        return CreatedAtAction(nameof(Get), new { id = play.id }, playDto);
        }catch(Exception ex){
                LogError(ex, "Error al crear una nueva obra");
                return StatusCode(500, "Error interno del servidor");
        }
    }


    // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] PlayUpdateDTO playDto)
        {
            try{
            var existingPlay = playService.GetPlay(id);

            if (existingPlay == null)
            {
                LogError(new Exception("No se encontró la obra"), $"Error al intentar acutalizar la obra con el id {id}");
                return NotFound();
            }

            
            if (playDto.title != null)
            {
                existingPlay.title = playDto.title;
            }

            if (playDto.descriptionPlay != null)
            {
                existingPlay.descriptionPlay = playDto.descriptionPlay;
            }

            if (playDto.synopsis != null)
            {
                existingPlay.synopsis = playDto.synopsis;
            }

            if (playDto.director != null)
            {
                existingPlay.director = playDto.director;
            }

             if (playDto.genre != null)
            {
                existingPlay.genre = playDto.genre;
            }

            playService.UpdatePlay(existingPlay);

            return NoContent();
        }catch(Exception ex){
                LogError(ex, "Error al actualizar la obra");
                return StatusCode(500, "Error interno del servidor");
        }
        }

    // DELETE action
   [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try{
        var play = playService.GetPlay(id);
    
        if (play is null){
            LogError(new Exception($"No se encontró la obra con ID {id}"), "Error al intentar eliminar la obra");
            return NotFound();
        }
        
        playService.DeletePlay(id);
    
        return NoContent();
        }catch(Exception ex){
                LogError(ex, "Error al eliminar la obra");
                return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("{id}/tickets")]
    public ActionResult<List<TicketDTO>> GetBoughtTickets(int id){
        try{
        var tickets = playService.GetBoughtTickets(id);
        if(tickets== null || tickets.Count==0){
            LogError(new Exception($"No se encontraron tickets con la obra de ID {id}"), "Error al intentar obtener los tickets");
            return NotFound();
        }else{
            return tickets;
        }
        }catch(Exception ex){
                LogError(ex, "Error al obtener los tickets");
                return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("Genre/{genre}")]
    public ActionResult<List<PlayDTO>> GetPlaysByGenre(string genre){
        try{
        var plays = playService.GetPlaysByGenre(genre);
        if(plays== null || plays.Count==0){
            LogError(new Exception($"No se encontraron obras con el genero {genre}"), "Error al intentar obtener las obras");
            return NotFound();
        }else{
            return plays;
        }
        }catch(Exception ex){
                LogError(ex, "Error al obtener la obra por género");
                return StatusCode(500, "Error interno del servidor");
        }
    }

    //logger
    private void LogError(Exception ex, string message)
    {
        _logger.LogError(ex, message);
        
        var logFilePath = "../logs/error-log.txt";
        System.IO.File.AppendAllText(logFilePath, $"{DateTime.Now} - {message}: {ex.Message}\n");

        Console.WriteLine($"Error al escribir en el log: {ex.Message}");

    }


}