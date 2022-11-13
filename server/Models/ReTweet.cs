using System.Text.Json.Serialization;

namespace server.Models
{
    public class ReTweet
    {
        public int Id { get; set; }
        public Tweet Retweet { get; set; }
    }
}