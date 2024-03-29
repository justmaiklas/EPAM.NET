﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApiTask.Models;

namespace WebApiTask.Repository
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(DatabaseContext context) : base(context)
        {
            if (!context.Team.Any()) DatabaseContext.SeedTeams(context);

        }

        public List<Team> GetAllTeams()
        {
            var list = _context.Team.Include(t => t.Players).ToList();
            return list;
        }

    }
}
