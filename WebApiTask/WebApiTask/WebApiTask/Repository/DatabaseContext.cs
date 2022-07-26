using Microsoft.EntityFrameworkCore;
using WebApiTask.Models;

namespace WebApiTask.Repository
{
    public class DatabaseContext : DbContext
    {
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //GenerateTeams();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql(@"Host=localhost;Port=5432;Database=webApiTask;Username=postgres;Password=test");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Player>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Team>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Team>().HasMany(e => e.Players);
        }

        public DbSet<Team> Team { get; set; }
        public DbSet<Player> Player { get; set; }

        
        private static Player GetRandomPlayer()
        {
            var random = new Random();
            var positions = new[] { "Point guard", "Shoot guard", "Small forward", "Power forward", "Center" };
            var names = new[] { "Tadas", "Martynas", "Aleksas", "Simas", "Rokas", "Šarūnas", "Lukas", "Adomas", "Robertas", "Mykolas" };
            var player = new Player { Age = random.Next(18, 50), Name = names[random.Next(0, names.Length - 1)], Id = Guid.NewGuid(), Position = positions[random.Next(0, positions.Length - 1)] };
            return player;
        }

        private static List<Player> GeneratePlayersList(int amount = 6)
        {
            var players = new List<Player>();
           
            for (var i = 0; i < amount; i++)
            {
                players.Add(GetRandomPlayer());
            }
            
            return players;
        }
        public static void SeedPlayers(DatabaseContext context, int amount = 20, List<Player> players = null)
        {
            players ??= GeneratePlayersList(amount);
            context.Player.AddRange(players);
            context.SaveChanges();
        }
        private static Team GetRandomTeam(int teamPlayersCount = 0)
        {
            var random = new Random();
            var teams = new[] { "Boston Celtics", "Los Angeles Lakers", "Chicago Bulls", "New York Knicks", "Philadelphia 76ers", "Toronto Raptors", "Oklahoma City Thunder", "San Antonio Spurs", "Utah Jazz", "Golden State Warriors", "Cleveland Cavaliers", "Milwaukee Bucks", "Dallas Mavericks", "Houston Rockets", "Washington Wizards" };
            var team = new Team { Id = Guid.NewGuid(), Name = teams[random.Next(0, teams.Length - 1)] };
            var players = GeneratePlayersList(teamPlayersCount);
            team.Players = players;
            return team;
        }

        public static void SeedTeams(DatabaseContext context, int amount = 2)
        {
            var teams = new List<Team>();
            for (var i = 0; i < amount; i++)
            {
                var team = GetRandomTeam();
                teams.Add(team);
            }
            context.Team.AddRange(teams);
            context.SaveChanges();

        }
        
    }
    
}
