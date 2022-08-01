﻿using Microsoft.Extensions.Options;
using WebApiTask.Models;

namespace WebApiTask.Repository
{
    public class TeamRepository : GenericRepository<Team>, IPlayerRepository
    {
        public TeamRepository(DatabaseContext context) : base(context)
        {
            if (!context.Team.Any()) DatabaseContext.SeedTeams(context);

        }

    }
}