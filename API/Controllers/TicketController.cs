using TeatroWeb.Models;
using TeatroWeb.Business;
using Microsoft.AspNetCore.Mvc;
using TeatroWeb.common;

namespace TeatroWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService? ticketService;
    private readonly IlogError _logError;
    public TicketController(IlogError logError,ITicketService? _ticketService)
    {
        _logError=logError;
        ticketService=_ticketService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<TicketDTO>> GetAll() {
    try{
            return ticketService.GetAll();
      }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de los tickets");
            return StatusCode(500, "Error interno del servidor");
        }
    }
    
    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<TicketDTO> Get(int id)
    {
        try{
        var ticket = ticketService.GetTicket(id);

        if(ticket == null){
            _logError.LogErrorMethod(new Exception("No se encontró el ticket"), $"Error al obtener la información del ticket con ID {id}");
            return NotFound();
        }

        return ticket;
        }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información del ticket con el id {id}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
    // POST action
    [HttpPost]
    public IActionResult Create([FromBody] TicketCreateDTO ticketDTO)
    { 
        try{           
        if (!ModelState.IsValid)
        {
            _logError.LogErrorMethod(new Exception("No se pudo crear el ticket"), $"Error al almacenar la información del ticket {ModelState}");
            return BadRequest(ModelState);
        }
        var ticket= new Ticket{
            TicketRow = ticketDTO.TicketRow!,
            TicketColumn = ticketDTO.TicketColumn!,
            price = ticketDTO.price!,
            scheduleTicket = ticketDTO.scheduleTicket!,
            userId = ticketDTO.userId!,
            playId = ticketDTO.playId!
        };

        ticketService.AddTicket(ticket);
        return CreatedAtAction(nameof(Get), new { id = ticket.id }, ticketDTO);
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al crear un nuevo ticket");
                return StatusCode(500, "Error interno del servidor");
        }
    }
    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id,[FromBody] TicketUpdateDTO ticketDTO)
    {
        try{
        var existingTicket = ticketService.GetTicket(id);
        if(existingTicket == null){
            _logError.LogErrorMethod(new Exception("No se encontró el ticket"), $"Error al intentar acutalizar el ticket con el id {id}");
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
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al actualizar el ticket");
                return StatusCode(500, "Error interno del servidor");
        }
    }
    // DELETE action
   [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try{
        var ticket = ticketService.GetTicket(id);
    
        if (ticket is null){
            _logError.LogErrorMethod(new Exception($"No se encontró el ticket con ID {id}"), "Error al intentar eliminar el ticket");
            return NotFound();
        }
        
        ticketService.DeleteTicket(id);
    
        return NoContent();
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al eliminar el ticket");
                return StatusCode(500, "Error interno del servidor");
        }
    }

}