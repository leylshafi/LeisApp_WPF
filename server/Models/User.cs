namespace server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        public string? ProfilePicture { get; set; }
        public string? BannerPicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Bio { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Tweet>? Tweets { get; set; }
        public List<Following>? Following { get; set; }
        public List<Follower>? Followers { get; set; }
    }
}
