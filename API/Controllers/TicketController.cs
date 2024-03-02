using TeatroWeb.Models;
using TeatroWeb.Business;
using Microsoft.AspNetCore.Mvc;

namespace TeatroWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService? ticketService;
    public TicketController(ITicketService? _ticketService)
    {
        ticketService=_ticketService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<TicketDTO>> GetAll() =>
        ticketService.GetAll();
    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<TicketDTO> Get(int id)
    {
        var ticket = ticketService.GetTicket(id);

        if(ticket == null)
            return NotFound();

        return ticket;
    }
    // POST action
    [HttpPost]
    public IActionResult Create([FromBody] TicketCreateDTO ticketDTO)
    {            
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var ticket= new Ticket{
            TicketRow = (int)ticketDTO.TicketRow!,
            TicketColumn = (int)ticketDTO.TicketColumn!,
            price = (decimal)ticketDTO.price!,
            scheduleTicket = (DateTime)ticketDTO.scheduleTicket!,
            userId = (int)ticketDTO.userId!,
            playId = (int)ticketDTO.playId!
        };

        ticketService.AddTicket(ticket);
        return CreatedAtAction(nameof(Get), new { id = ticket.id }, ticketDTO);
    }
    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id,[FromBody] TicketUpdateDTO ticketDTO)
    {
        var existingTicket = ticketService.GetTicket(id);
        if(existingTicket == null){
            return NotFound();
        }
        var newTicketUpdated=new Ticket{
            id = existingTicket.id,
            TicketRow = existingTicket.TicketRow,
            TicketColumn = existingTicket.TicketColumn,
            price =  existingTicket.price,
            scheduleTicket = existingTicket.scheduleTicket,
            userId = existingTicket.userId,
            playId = existingTicket.playId
        };

        if(ticketDTO.TicketRow!=null){
            newTicketUpdated.TicketRow= (int)ticketDTO.TicketRow;
        }
        if(ticketDTO.TicketColumn!=null) {
            newTicketUpdated.TicketColumn= (int)ticketDTO.TicketColumn;
        }
        if(ticketDTO.price!=null){
            newTicketUpdated.price= (decimal)ticketDTO.price;
        }  
        if(ticketDTO.scheduleTicket!=null){
            newTicketUpdated.scheduleTicket= (DateTime)ticketDTO.scheduleTicket;
        }
        ticketService.UpdateTicket(newTicketUpdated);           
    
        return NoContent();
    }
    // DELETE action
   [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var ticket = ticketService.GetTicket(id);
    
        if (ticket is null)
            return NotFound();
        
        ticketService.DeleteTicket(id);
    
        return NoContent();
    }
}