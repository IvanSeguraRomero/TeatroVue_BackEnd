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
    public IActionResult Create(Play play)
    {            
        playService.AddPlay(play);
        return CreatedAtAction(nameof(Get), new { id = play.id }, play);
    }
    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Play play)
    {
        if (id != play.id)
            return BadRequest();
            
        var existingPlay = playService.GetPlay(id);
        if(existingPlay is null)
            return NotFound();
    
        // Update the properties of the existingPlay entity with the values from the input play
        existingPlay.id = play.id; // Update all relevant properties accordingly

        // Call a method in your service layer to update the existingPlay entity
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