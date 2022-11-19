using System.Text.Json.Serialization;

namespace server.Models
{
    public class Tweet
    {
        public int Id { get; set; } 
        public string Content { get; set; }
        public List<Comment>? Comments { get; set; }
        public int LikesCount { get; set; }
        public DateTime Created { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}