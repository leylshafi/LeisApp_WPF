﻿using System;

namespace Source.Models.Dtos
{
    public class TweetDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }
    }
}
