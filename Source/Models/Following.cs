using System.Text.Json.Serialization;

namespace Source.Models
{
    public class Following
    {
        public int Id { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}