using TeatroWeb.Models;
using TeatroWeb.Business;
using Microsoft.AspNetCore.Mvc;

namespace TeatroWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService? userService;
    public UserController(IUserService? _userService)
    {
        userService=_userService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<UserDTO>> GetAll() =>
        userService.GetAll();
    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<UserDTO> Get(int id)
    {
        var user = userService.GetUserDTO(id);
        
        if(user == null)
            return NotFound();

        return user;
    }
    // POST action
    [HttpPost]
    public IActionResult Create([FromBody]UserCreateDTO userDTO)
    {         
        if (!ModelState.IsValid)
        {
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
    }
    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id,[FromBody] UserUpdateDTO userDTO)
    {       
        var existingUser = userService.GetUser(id);
        if(existingUser is null)
            return NotFound();

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
    }
    // DELETE action
   [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = userService.GetUser(id);
    
        if (user is null)
            return NotFound();
        
        userService.DeleteUser(id);
    
        return NoContent();
    }

    [HttpGet("{id}/tickets")]
    public ActionResult<List<TicketDTO>> GetUserTickets(int id){
        var tickets = userService.GetUserTickets(id);
        if(tickets== null){
            return NotFound();
        }else{
            return tickets;
        }
    }

}