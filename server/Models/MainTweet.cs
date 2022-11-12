using System.Text.Json.Serialization;

namespace server.Models
{
    public class MainTweet
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}