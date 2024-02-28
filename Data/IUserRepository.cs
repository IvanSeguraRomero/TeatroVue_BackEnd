using TeatroWeb.Models;

namespace TeatroWeb.Data{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUser(int id);
        void UpdateUser (User user);
        void DeleteUser(int id);
        List<User> GetAll();
        List<Ticket> GetUserTickets();
    }
}