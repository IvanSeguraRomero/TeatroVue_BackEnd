using TeatroWeb.Models;
namespace TeatroWeb.Business;
public interface IPlayService
{
        void AddPlay(Play play);
        PlayDTO GetPlayDTO(int id);
        Play GetPlay(int id);
        void UpdatePlay (Play play);
        void DeletePlay(int id);
        List<PlayDTO> GetAll();
        List<TicketDTO> GetBoughtTickets(int id);
        List<PlayDTO> GetPlaysByGenre(string genre);

}
