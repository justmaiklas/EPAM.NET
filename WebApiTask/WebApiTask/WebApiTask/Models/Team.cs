namespace WebApiTask.Models
{
    public class Team
    {
        public Team()
        {
            Players = new List<Player>();
            Name = "";
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
    }
}
