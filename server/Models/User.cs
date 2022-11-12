namespace server.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public Person Person { get; set; }
        public List<Tweet>? Tweets { get; set; }
        public List<Reply>? Replies { get; set; }
        public List<Like>? Likes { get; set; }
    }
}
