using TeatroWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace TeatroWeb.Data{

    public class PlayEFRepository : IPlayRepository
    {

        private readonly TeatroBackendContext _context;

        public PlayEFRepository(TeatroBackendContext context){
            _context=context;
        }
        public void AddPlay(Play play)
        {
            _context.Plays.Add(play);
            SaveChanges();
        }

        public void DeletePlay(int id)
        {
            var play=_context.Plays.Find(id);
            if(play==null){
                throw new KeyNotFoundException("Play not found.");
            }
            _context.Plays.Remove(play);
            SaveChanges();
        }

        public List<PlayDTO> GetAll()
        {   
            var ticketRepository = new TicketEFRepository(_context);
            var plays=_context.Plays.Include(p => p.tickets).ToList();
            var playsDTO = plays.Select(p => new PlayDTO{
                id=p.id,
                title=p.title,
                descriptionPlay=p.descriptionPlay,
                synopsis=p.synopsis,
                director=p.director,
                genre=p.genre,
                tickets=ticketRepository.GetTicketOfPlay(p.id)
            }).ToList();
            return playsDTO;
            // var plays = _context.Plays.ToList();
            // return plays;
        }

        public PlayDTO GetPlayDTO(int id)
        {
            var play=_context.Plays.Include(p => p.tickets).ToList();
            if(play==null){
                throw new KeyNotFoundException("Play not found.");
            }
            var ticketRepository = new TicketEFRepository(_context);
            var playDTO = play.Select(p => new PlayDTO{
                id=p.id,
                title=p.title,
                descriptionPlay=p.descriptionPlay,
                synopsis=p.synopsis,
                director=p.director,
                genre=p.genre,
                tickets=ticketRepository.GetTicketOfPlay(p.id)
            }).FirstOrDefault(play => play.id ==id);
            return playDTO;
        }

        public Play GetPlay(int id){
            var play = _context.Plays.Include(p => p.tickets).FirstOrDefault(play => play.id == id);
            return play;
        }

        public void UpdatePlay(Play play)
        {
            _context.Entry(play).State=EntityState.Modified;
            SaveChanges();
        }

        public List<TicketDTO> GetBoughtTickets(int playId)
        {
            
            var ticketsForPlay = _context.Tickets
                                        .Where(ticket => ticket.playId == playId)
                                        .ToList();
            var ticketsForPlayDTO = ticketsForPlay.Select(t => new TicketDTO{
                id=t.id,
                TicketRow = t.TicketRow,
                TicketColumn = t.TicketColumn,
                price = t.price,
                scheduleTicket = t.scheduleTicket,
                userId = t.userId,
                playId = t.playId
            }).ToList();
            return ticketsForPlayDTO;
        }

        public List<PlayDTO> GetPlaysByGenre(string genre)
        {
            var playsGenre = _context.Plays
                             .Where(play => play.genre == genre)
                             .ToList();
            if (playsGenre == null){
                throw new KeyNotFoundException("Plays with the specific genre not found.");
            }
            var ticketRepository = new TicketEFRepository(_context);
            var playsDTO = playsGenre.Select(p => new PlayDTO{
                id=p.id,
                title=p.title,
                descriptionPlay=p.descriptionPlay,
                synopsis=p.synopsis,
                director=p.director,
                genre=p.genre,
                tickets=ticketRepository.GetTicketOfPlay(p.id)
            }).ToList();
            return playsDTO;

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        
    }
}