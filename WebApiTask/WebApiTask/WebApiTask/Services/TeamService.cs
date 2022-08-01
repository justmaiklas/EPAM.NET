using WebApiTask.Models;
using WebApiTask.Repository;

namespace WebApiTask.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
            
        public Team? GetTeamById(Guid id)
        {
            return _teamRepository.Get(id);
        }

        public List<Team> GetAllTeams()
        {
            return _teamRepository.GetAll().ToList();
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
            var team = _teamRepository.Get(teamId);
            if (team == null)
            {
                return null;
            }
            team.Players.Add(new Player(){Id = playerId});
            return _teamRepository.Update(team);
        }

        public Team? RemovePlayerFromTeam(Guid teamId, Guid playerId)
        {
            var team = _teamRepository.Get(teamId);
            if (team == null)
            {
                return null;
            }
            team.Players.RemoveAll(p => p.Id == playerId);
            return _teamRepository.Update(team);
        }
    }
}
