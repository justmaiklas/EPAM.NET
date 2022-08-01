using WebApiTask.Models;
using WebApiTask.Repository;
using WebApiTask.Services;

namespace WebApiTask
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public Player? GetPlayerById(Guid id)
        {
            return id == Guid.Empty ? null : _playerRepository.Get(id);
        }

        public List<Player> GetAllPlayers()
        {
            return _playerRepository.GetAll().ToList();
        }

        public Player? CreatePlayer(Player player)
        {
            return _playerRepository.Add(player);
        }

        public Player? UpdatePlayer(Player player)
        {
            if (GetPlayerById(player.Id) is null)
            {
                throw new Exception("Player not found");
            }
            return _playerRepository.Update(player);

        }

        public bool DeletePlayer(Guid id)
        {
            if (GetPlayerById(id) is null)
            {
                throw new Exception("Player not found");
            }
            return _playerRepository.Delete(id);
        }
    }


}
