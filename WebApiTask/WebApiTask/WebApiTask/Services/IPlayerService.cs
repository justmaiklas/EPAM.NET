using WebApiTask.Models;

namespace WebApiTask.Services
{
    public interface IPlayerService
    {
        public Player? GetPlayerById(Guid id);
        public List<Player> GetAllPlayers();
        public Player? CreatePlayer(Player player);
        public Player? UpdatePlayer(Guid id, string name, int Age, string position);
        public Player? DeletePlayer(Guid id);
    }
}
