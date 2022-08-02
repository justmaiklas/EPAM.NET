using WebApiTask.Models;

namespace WebApiTask.Repository;

public interface ITeamRepository : IGenericRepository<Team>
{
    public List<Team> GetAllTeams();
}