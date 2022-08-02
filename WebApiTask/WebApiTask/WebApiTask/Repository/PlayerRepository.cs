using Microsoft.Extensions.Options;
using WebApiTask.Models;

namespace WebApiTask.Repository
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DatabaseContext context) : base(context)
        {
            if (!context.Player.Any()) DatabaseContext.SeedPlayers(context);
        }
    }
}
