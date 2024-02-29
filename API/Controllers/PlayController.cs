using TeatroWeb.Models;
using TeatroWeb.Business;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<List<Play>> GetAll() =>
        playService.GetAll();
    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Play> Get(int id)
    {
        var play = playService.GetPlay(id);

        if(play == null)
            return NotFound();

        return play;
    }
    // POST action
    [HttpPost]
    public IActionResult Create(PlayCreateDTO playDto)
    {            
        if (!ModelState.IsValid)
        {
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
    }


    // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] PlayUpdateDTO playDto)
        {
            var existingPlay = playService.GetPlay(id);

            if (existingPlay == null)
            {
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
        }

    // DELETE action
   [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var play = playService.GetPlay(id);
    
        if (play is null)
            return NotFound();
        
        playService.DeletePlay(id);
    
        return NoContent();
    }

    [HttpGet("{id}/tickets")]
    public ActionResult<List<Ticket>> GetBoughtTickets(int id){
        var tickets = playService.GetBoughtTickets(id);
        if(tickets== null){
            return NotFound();
        }else{
            return tickets;
        }
    }

    [HttpGet("Genre/{genre}")]
    public ActionResult<List<Play>> GetPlaysByGenre(string genre){
        var plays = playService.GetPlaysByGenre(genre);
        if(plays== null){
            return NotFound();
        }else{
            return plays;
        }
    }

}