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
            return _playerRepository.Get(id);
        }

        public List<Player> GetAllPlayers()
        {
            return _playerRepository.GetAll().ToList();
        }
    }


}
