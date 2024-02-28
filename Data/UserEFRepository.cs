using TeatroWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace TeatroWeb.Data{

    public class UserEFRepository : IUserRepository
    {
        public readonly TeatroBackendContext _context;

        public UserEFRepository(TeatroBackendContext context){
            _context=context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user=_context.Users.Find(id);
            if(user==null){
                throw new KeyNotFoundException("Order not found.");
            }
            _context.Users.Remove(user);
            SaveChanges();
        }

        public List<User> GetAll()
        {
            var users=_context.Users.ToList();
            return users;
        }

        public User GetUser(int id)
        {
            var user=_context.Users.Find(id);
            if(user==null){
                throw new KeyNotFoundException("User not found.");
            }
            return user;
        }

        public List<Ticket> GetUserTickets(int id)
        {
            var ticketsUser=_context.Tickets
                                    .Where(ticket=>ticket.userId==id)
                                    .ToList();
             if (ticketsUser == null){
                throw new KeyNotFoundException("Tickets for user not found.");
            }
            return ticketsUser;                       
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State=EntityState.Modified;
            SaveChanges();
        }
         public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}