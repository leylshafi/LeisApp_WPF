using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Input;
using System.Windows.Media;

namespace Source.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public List<Comment>? Comments { get; set; }
        public int LikesCount { get; set; }
        public DateTime Created { get; set; }

        public ICommand? ShowCommand { get; set; }
        public ICommand? ShowProfileCommand { get; set; }

        public Brush? ForeColor { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}