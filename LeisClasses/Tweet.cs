namespace LeisClasses
{
    public class Tweet
    {
        public Guid Id { get; set; }
        public User User {get;set;}
        public string Content {get;set;}
        public List<string> Images {get;set;}
        public List<string> Videos {get;set;}
        public Tweet repTweet {get;set;}
        public List<Tweet> Comments {get;set;}
        public List<Tweet> Replies {get;set;}
        public List<User> Likes {get;set;}
    }
}