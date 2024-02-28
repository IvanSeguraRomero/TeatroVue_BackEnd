using TeatroWeb.Models;

namespace TeatroWeb.Data{
    public interface IPlayRepository
    {
        void AddPlay(Play play);
        Play GetPlay(int id);
        void UpdatePlay (Play play);
        void DeletePlay(int id);
        List<Play> GetAll();
        List<Ticket> GetBoughtTickets(int id);
        List<Play> GetPlaysByGenre(string genre);
    }
}

