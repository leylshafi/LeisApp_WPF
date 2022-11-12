using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Models;

public class Tweet:Entity
{
    // string will has been User
    public string? User { get; set; }
    public string? Content { get; set; }
}
