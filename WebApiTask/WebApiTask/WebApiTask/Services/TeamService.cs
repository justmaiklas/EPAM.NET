using WebApiTask.Models;
using WebApiTask.Repository;

namespace WebApiTask.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerRepository _playerRepository;

        public TeamService(ITeamRepository teamRepository, IPlayerRepository playerRepository)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
        }
            
        public Team? GetTeamById(Guid id)
        {
            return _teamRepository.Get(team => team.Id == id).FirstOrDefault();
        }

        public List<Team> GetAllTeams()
        {
            var teams = _teamRepository.GetAll(team => team.Players);
            return teams.ToList();
        }

        public Team? CreateTeam(Team team)
        {
            return _teamRepository.Add(team);
        }

        public Team? UpdateTeam(Team team)
        {
            return _teamRepository.Update(team);
        }

        public bool DeleteTeam(Guid id)
        {
            return _teamRepository.Delete(id);
        }

        public Team? AddPlayerToTeam(Guid teamId, Guid playerId)
        {
            var team = _teamRepository.Get(team => team.Id == teamId).FirstOrDefault();
            var player = _playerRepository.Get(player => player.Id == playerId).FirstOrDefault();
            if (team == null || player == null)
            {
                throw new ArgumentException("Team or player not found");
            }
            if (team.Players.Find(p => p.Id == player.Id) != null)
            {
                throw new ArgumentException("Player already in team");
            }

            team.Players.Add(player);
            player.Team = team;
            _playerRepository.Update(player);
            return _teamRepository.Update(team);
        }

        public Team? RemovePlayerFromTeam(Guid teamId, Guid playerId)
        {
            var team = _teamRepository.Get(team => team.Id == teamId).FirstOrDefault();
            var player = _playerRepository.Get(player => player.Id == playerId).FirstOrDefault();
            if (team == null || player == null)
            {
                throw new ArgumentException("Team or player not found");
            }
            team.Players.RemoveAll(p => p.Id == playerId);
            return _teamRepository.Update(team);
        }
    }
}
