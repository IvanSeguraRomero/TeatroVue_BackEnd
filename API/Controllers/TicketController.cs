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
    [HttpGet]
    [Route("{id}")]
    public ActionResult<TicketDTO> Get(int id)
    {
        var ticket = ticketService.GetTicket(id);

        if(ticket == null)
            return NotFound();

        return ticket;
    }
    // POST action
    [HttpPost]
    public IActionResult Create(Ticket ticket)
    {            
        ticketService.AddTicket(ticket);
        return CreatedAtAction(nameof(Get), new { id = ticket.id }, ticket);
    }
    // PUT action
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(int id, Ticket ticket)
    {
        if (id != ticket.id)
            return BadRequest();
            
        var existingTicket = ticketService.GetTicket(id);
        if(existingTicket is null)
            return NotFound();
    
        ticketService.UpdateTicket(ticket);           
    
        return NoContent();
    }
    // DELETE action
   [HttpDelete]
   [Route("{id}")]
    public IActionResult Delete(int id)
    {
        var ticket = ticketService.GetTicket(id);
    
        if (ticket is null)
            return NotFound();
        
        ticketService.DeleteTicket(id);
    
        return NoContent();
    }
}