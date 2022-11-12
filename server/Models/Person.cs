namespace server.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string ProfilePicture { get; set; }
        public string BannerPicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDate { get; set; }
    }
}