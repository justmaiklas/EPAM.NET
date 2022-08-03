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
            return _playerRepository.Get(p => p.Id == id, player => player.Team!).FirstOrDefault();
        }

        public List<Player> GetAllPlayers()
        {
            return _playerRepository.GetAll(player => player.Team!).ToList();
        }

        public Player? CreatePlayer(Player player)
        {
            return _playerRepository.Add(player);
        }

        public Player? UpdatePlayer(Guid id, string name, int age, string position)
        {
            var player = GetPlayerById(id);
            if (player is null)
            {
                return null;
            }
            player.Name = name;
            player.Age = age;
            player.Position = position;
            
            return _playerRepository.Update(player);

        }

        public Player? DeletePlayer(Guid id)
        {
            var player = GetPlayerById(id);
            if (player is null)
            {
                return null;
            }
            _playerRepository.Delete(player);
            return player;
        }
    }


}
