using TeatroWeb.Models;

namespace TeatroWeb.Data{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUser(int id);
        UserDTO GetUserDTO(int id);
        void UpdateUser (User user);
        void DeleteUser(int id);
        List<UserDTO> GetAll();
        List<TicketDTO> GetUserTickets(int id);
    }
}