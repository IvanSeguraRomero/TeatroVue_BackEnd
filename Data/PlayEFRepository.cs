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

        public List<Play> GetAll()
        {
            var plays=_context.Plays.ToList();
            return plays;
        }

        public Play GetPlay(int id)
        {
            var play=_context.Plays.Find(id);
            if(play==null){
                throw new KeyNotFoundException("Play not found.");
            }
            return play;
        }

        public void UpdatePlay(Play play)
        {
            _context.Entry(play).State=EntityState.Modified;
            SaveChanges();
        }

        public List<Ticket> GetBoughtTickets(int playId)
        {
            
            var ticketsForPlay = _context.Tickets
                                        .Where(ticket => ticket.playId == playId)
                                        .ToList();
            return ticketsForPlay;
        }

        public List<Play> GetPlaysByGenre(string genre)
        {
            var playsGenre = _context.Plays
                             .Where(play => play.genre == genre)
                             .ToList();

            if (playsGenre == null){
                throw new KeyNotFoundException("Plays with the specific genre not found.");
            }
            return playsGenre;

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        
    }
}