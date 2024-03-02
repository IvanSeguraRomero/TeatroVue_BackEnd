namespace TeatroWeb.Business;

using TeatroWeb.Models;
using TeatroWeb.Data;
using System.Collections.Generic;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository){
        _repository=repository;
    }
    public void AddUser(User user)
    {
        _repository.AddUser(user);
    }

    public void DeleteUser(int id)
    {
        _repository.DeleteUser(id);
    }

    public List<UserDTO> GetAll()
    {
        var users=_repository.GetAll();
        return users;
    }

    public User GetUser(int id)
    {
        var user=_repository.GetUser(id);
        return user;
    }

    public void UpdateUser(User user)
    {
        _repository.UpdateUser(user);
    }

     public List<TicketDTO> GetUserTickets(int id)
    {
        var tickets=_repository.GetUserTickets(id);
        return tickets;
    }

    public UserDTO GetUserDTO(int id)
    {
        var user=_repository.GetUserDTO(id);
        return user;
    }
}