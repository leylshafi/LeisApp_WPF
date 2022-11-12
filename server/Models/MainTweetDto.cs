using System.Text.Json.Serialization;

namespace server.Models
{
    public class MainTweetDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
    }
}
