using TeatroWeb.Models;

namespace TeatroWeb.Business{
    public interface IUserService
    {
        void AddUser(User user);
        User GetUser(int id);
        void UpdateUser (User user);
        void DeleteUser(int id);
        List<User> GetAll();
        List<Ticket> GetUserTickets(int id);
    }
}