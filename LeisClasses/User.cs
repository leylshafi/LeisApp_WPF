using System.ComponentModel.DataAnnotations;

namespace LeisClasses
{
    public class User
    {
        [Key]
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public Person? Person { get; set; }
    }
}