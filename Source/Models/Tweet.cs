﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Models;

public class Tweet:Entity
{
    public User? User { get; set; }
    public string? Username { get; set; }
    public string? Content { get; set; }
    public DateTime Date { get; set; }

    public string? UserWithAt => $"@{Username}";

}
