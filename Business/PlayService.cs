namespace TeatroWeb.Business;

using TeatroWeb.Models;
using TeatroWeb.Data;
using System.Collections.Generic;

public class PlayService : IPlayService
{
    private readonly IPlayRepository _repository;

    public PlayService(IPlayRepository repository){
        _repository=repository;
    }
    public void AddPlay(Play play)
    {
        _repository.AddPlay(play);
    }

    public void DeletePlay(int id)
    {
        _repository.DeletePlay(id);
    }

    public List<PlayDTO> GetAll()
    {
        var plays=_repository.GetAll();
        return plays;
    }

    public List<TicketDTO> GetBoughtTickets(int id)
    {
        var tickets=_repository.GetBoughtTickets(id);
        return tickets;
    }

    public PlayDTO GetPlayDTO(int id)
    {
        var play=_repository.GetPlayDTO(id);
        return play;
    }
    public Play GetPlay(int id)
    {
        var play=_repository.GetPlay(id);
        return play;
    }

    public List<PlayDTO> GetPlaysByGenre(string genre)
    {
        var plays=_repository.GetPlaysByGenre(genre);
        return plays;
    }

    public void UpdatePlay(Play play)
    {
        _repository.UpdatePlay(play);
    }
}