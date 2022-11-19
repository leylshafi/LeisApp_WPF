namespace server.Models.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ReplingTo { get; set; }
        public DateTime Created { get; set; }
        public int TweetId { get; set; }
    }
}
