using WebApiTask.Models;

namespace WebApiTask.Services
{
    public interface ITeamService
    {
        public Team GetTeamById(Guid id);
        public List<Team> GetAllTeams();
    }
}
