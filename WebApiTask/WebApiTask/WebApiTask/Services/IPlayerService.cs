using WebApiTask.Models;

namespace WebApiTask.Services
{
    public interface IPlayerService
    {
        public Player? GetPlayerById(Guid id);
        public List<Player> GetAllPlayers();
        public Player? CreatePlayer(Player player);
        public Player? UpdatePlayer(Player player);
        public bool DeletePlayer(Guid id);
    }
}
