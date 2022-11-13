using System.Text.Json.Serialization;

namespace server.Models
{
    public class Follower
    {
        public int Id { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}