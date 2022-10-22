namespace LeisClasses
{
    public class Person
    {
        public int Id { get; set; }
        public string ProfilePic { get; set; }
        public string BannerPic { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Tweet> Tweets { get; set; }
        public List<Tweet> Replies { get; set; }
        public List<Tweet> Likes { get; set; }
        public List<Tweet> Media { get; set; }
        public List<User> Following { get; set; }
        public List<User> Followers { get; set; }
    }
}