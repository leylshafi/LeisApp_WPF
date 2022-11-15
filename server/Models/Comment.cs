using System.Text.Json.Serialization;

namespace server.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ReplingTo { get; set; }
        public int LikesCount { get; set; }
        public DateTime Created { get; set; }
        [JsonIgnore]
        public Tweet Tweet { get; set; }
        public int TweetId { get; set; }
    }
}