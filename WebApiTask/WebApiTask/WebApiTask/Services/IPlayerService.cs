using WebApiTask.Models;

namespace WebApiTask.Services
{
    public interface IPlayerService
    {
        public Player? GetPlayerById(Guid id);
        public List<Player> GetAllPlayers();
    }
}
