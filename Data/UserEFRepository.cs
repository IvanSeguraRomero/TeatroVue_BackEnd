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

        public List<UserDTO> GetAll()
        {
            var ticketRepository = new TicketEFRepository(_context);
            var users=_context.Users.Include(u=>u.tickets).ToList();
            var usersDTO=users.Select(u=> new UserDTO{
                id=u.id,
                username=u.username,
                surname=u.surname,
                passwd=u.passwd,
                direction=u.direction,
                email=u.email,
                notes=u.notes,
                tlf=u.tlf,
                payment=u.payment,
                tickets=ticketRepository.GetTicketOfPlay(u.id)
            }).ToList();

            return usersDTO;
        }

        public User GetUser(int id)
        {
            var user=_context.Users.Find(id);
            if(user==null){
                throw new KeyNotFoundException("User not found.");
            }
            return user;
        }

          public UserDTO GetUserDTO(int id)
        {
            var user=_context.Users.Include(u=>u.tickets).ToList();
            if(user==null){
                throw new KeyNotFoundException("User not found.");
            }
            var ticketRepository = new TicketEFRepository(_context);

            var userDTO=user.Select(u=> new UserDTO{
                id=u.id,
                username=u.username,
                surname=u.surname,
                passwd=u.passwd,
                direction=u.direction,
                email=u.email,
                notes=u.notes,
                tlf=u.tlf,
                payment=u.payment,
                tickets=ticketRepository.GetTicketOfPlay(u.id)
            }).FirstOrDefault(user => user.id ==id);

            return userDTO;
        }

        public List<TicketDTO> GetUserTickets(int id)
        {
            var ticketsUser=_context.Tickets
                                    .Where(ticket=>ticket.userId==id)
                                    .ToList();
            var ticketsForUserDTO = ticketsUser.Select(t => new TicketDTO{
                id=t.id,
                TicketRow = t.TicketRow,
                TicketColumn = t.TicketColumn,
                price = t.price,
                scheduleTicket = t.scheduleTicket,
                userId = t.userId,
                playId = t.playId  
            }).ToList();
            return ticketsForUserDTO;                       
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