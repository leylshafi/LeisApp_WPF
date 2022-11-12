﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Models;

public class User
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Fullname => $"{Name} {Surname}";
}
