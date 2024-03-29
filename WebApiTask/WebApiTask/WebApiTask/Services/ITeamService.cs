﻿using WebApiTask.Models;

namespace WebApiTask.Services
{
    public interface ITeamService
    {
        public Team? GetTeamById(Guid id);
        public List<Team> GetAllTeams();
        public Team? CreateTeam(Team team);
        public Team? UpdateTeam(Team team);
        public Team? DeleteTeam(Guid id);
        public Team? AddPlayerToTeam(Guid teamId, Guid playerId);
        public Team? RemovePlayerFromTeam(Guid teamId, Guid playerId);
    }
}
