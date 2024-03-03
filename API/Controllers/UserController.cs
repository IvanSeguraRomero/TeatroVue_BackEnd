using TeatroWeb.Models;
using TeatroWeb.Business;
using Microsoft.AspNetCore.Mvc;

namespace TeatroWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService? userService;
    public UserController(ILogger<UserController> logger,IUserService? _userService)
    {
        userService=_userService;
        _logger=logger;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<UserDTO>> GetAll(){
        try{
        return userService.GetAll();
        }catch (Exception ex)
        {
            LogError(ex, $"Error al obtener la información de los usuarios");
            return StatusCode(500, "Error interno del servidor");
        }
    }
    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<UserDTO> Get(int id)
    {
        try{
        var user = userService.GetUserDTO(id);
        
        if(user == null){
            LogError(new Exception("No se encontró el usuario"), $"Error al obtener la información del usuario con id {id}");
            return NotFound();
        }

        return user;
        }catch (Exception ex)
        {
            LogError(ex, $"Error al obtener la información del usuario con id {id}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
    // POST action
    [HttpPost]
    public IActionResult Create([FromBody]UserCreateDTO userDTO)
    {      
        try{ 
          
        if (!ModelState.IsValid)
        {
            LogError(new Exception("No se pudo crear el usuario"), $"Error al almacenar la información del usuario {ModelState}");
            return BadRequest(ModelState);
        }   
        var user = new User
        {
            username=userDTO.username,
            surname=userDTO.surname,
            passwd=userDTO.passwd,
            direction=userDTO.direction,
            email=userDTO.email,
            notes=userDTO.notes,
            tlf=userDTO.tlf,
            payment=userDTO.payment
        };

        userService.AddUser(user);
        return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }catch (Exception ex)
        {
            LogError(ex, $"Error al crear un nuevo usuario");
            return StatusCode(500, "Error interno del servidor");
        }
    }
    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id,[FromBody] UserUpdateDTO userDTO)
    {       
        try{
        var existingUser = userService.GetUser(id);
        if(existingUser == null){
            LogError(new Exception("No se encontró el usuario"), $"Error al intentar acutalizar el usuario con id {id}");
            return NotFound();
        }

        if (userDTO.username != null)
        {
            existingUser.username = userDTO.username;
        }

        if (userDTO.surname != null)
        {
            existingUser.surname = userDTO.surname;
        }

        if (userDTO.passwd != null)
        {
            existingUser.passwd = userDTO.passwd;
        }

        if (userDTO.direction != null)
        {
            existingUser.direction = userDTO.direction;
        }

        if (userDTO.email != null)
        {
            existingUser.email = userDTO.email;
        }

        if (userDTO.notes != null)
        {
            existingUser.notes = userDTO.notes;
        }

        if (userDTO.tlf != null)
        {
            existingUser.tlf = (int)userDTO.tlf;
        }

        if (userDTO.payment != null)
        {
            existingUser.payment = userDTO.payment;
        }

        userService.UpdateUser(existingUser);
    
        return NoContent();
        }catch (Exception ex){
            LogError(ex, $"Error al actualizar el usuario");
            return StatusCode(500, "Error interno del servidor");
        }
    }
    // DELETE action
   [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try{
        var user = userService.GetUser(id);
    
        if (user == null){
            LogError(new Exception($"No se encontró el usuario con id {id}"), "Error al intentar eliminar el usuario");
            return NotFound();
        }
        
        userService.DeleteUser(id);
    
        return NoContent();
        }catch (Exception ex){
            LogError(ex, $"Error al eliminar el usuario");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("{id}/tickets")]
    public ActionResult<List<TicketDTO>> GetUserTickets(int id){
        try{
        var tickets = userService.GetUserTickets(id);
        if(tickets== null || tickets.Count==0){
            LogError(new Exception($"No se encontraron tickets del usuario con id {id}"), "Error al intentar obtener los tickets");
            return NotFound();
        }else{
            return tickets;
        }
        }catch (Exception ex){
            LogError(ex, $"Error al obtener los tickets");
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