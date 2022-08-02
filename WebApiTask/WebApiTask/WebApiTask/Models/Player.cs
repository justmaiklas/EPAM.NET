
namespace WebApiTask.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Position { get; set; }
        public Guid? TeamId { get; set; }
        public Team? Team { get; set; }

    }
}
