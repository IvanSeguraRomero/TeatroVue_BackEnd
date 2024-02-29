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
    public ActionResult<List<User>> GetAll() =>
        userService.GetAll();
    // GET by Id action
    [HttpGet]
    [Route("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = userService.GetUser(id);

        if(user == null)
            return NotFound();

        return user;
    }
    // POST action
    [HttpPost]
    public IActionResult Create(User user)
    {            
        userService.AddUser(user);
        return CreatedAtAction(nameof(Get), new { id = user.id }, user);
    }
    // PUT action
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(int id, User user)
    {
        if (id != user.id)
            return BadRequest();
            
        var existingUser = userService.GetUser(id);
        if(existingUser is null)
            return NotFound();
    
        userService.UpdateUser(user);           
    
        return NoContent();
    }
    // DELETE action
   [HttpDelete]
   [Route("{id}")]
    public IActionResult Delete(int id)
    {
        var user = userService.GetUser(id);
    
        if (user is null)
            return NotFound();
        
        userService.DeleteUser(id);
    
        return NoContent();
    }

    [HttpGet]
    [Route("{id}/tickets")]
    public ActionResult<List<Ticket>> GetUserTickets(int id){
        var tickets = userService.GetUserTickets(id);
        if(tickets== null){
            return NotFound();
        }else{
            return tickets;
        }
    }

}