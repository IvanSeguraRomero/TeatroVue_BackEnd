using TeatroWeb.Models;
using TeatroWeb.Business;
using Microsoft.AspNetCore.Mvc;
using TeatroWeb.common;

namespace TeatroWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IlogError _logError;
    private readonly IUserService? userService;
    public UserController(IlogError logError,IUserService? _userService)
    {
        userService=_userService;
        _logError=logError;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<UserDTO>> GetAll(){
        try{
        return userService.GetAll();
        }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de los usuarios");
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
            _logError.LogErrorMethod(new Exception("No se encontró el usuario"), $"Error al obtener la información del usuario con id {id}");
            return NotFound();
        }

        return user;
        }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información del usuario con id {id}");
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
            _logError.LogErrorMethod(new Exception("No se pudo crear el usuario"), $"Error al almacenar la información del usuario {ModelState}");
            return BadRequest(ModelState);
        }   
        if(userDTO.direction==null){
            userDTO.direction="";
            }
        if(userDTO.notes==null){
            userDTO.notes="";
        }
        if(userDTO.payment==null){
            userDTO.payment="";
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
            _logError.LogErrorMethod(ex, $"Error al crear un nuevo usuario");
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
            _logError.LogErrorMethod(new Exception("No se encontró el usuario"), $"Error al intentar acutalizar el usuario con id {id}");
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
            _logError.LogErrorMethod(ex, $"Error al actualizar el usuario");
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
            _logError.LogErrorMethod(new Exception($"No se encontró el usuario con id {id}"), "Error al intentar eliminar el usuario");
            return NotFound();
        }
        
        userService.DeleteUser(id);
    
        return NoContent();
        }catch (Exception ex){
            _logError.LogErrorMethod(ex, $"Error al eliminar el usuario");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("{id}/tickets")]
    public ActionResult<List<TicketDTO>> GetUserTickets(int id){
        try{
        var tickets = userService.GetUserTickets(id);
        if(tickets== null || tickets.Count==0){
            _logError.LogErrorMethod(new Exception($"No se encontraron tickets del usuario con id {id}"), "Error al intentar obtener los tickets");
            return NotFound();
        }else{
            return tickets;
        }
        }catch (Exception ex){
            _logError.LogErrorMethod(ex, $"Error al obtener los tickets");
            return StatusCode(500, "Error interno del servidor");
        }
    }

}