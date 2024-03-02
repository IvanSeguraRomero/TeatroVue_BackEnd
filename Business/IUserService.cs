using TeatroWeb.Models;

namespace TeatroWeb.Business{
    public interface IUserService
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