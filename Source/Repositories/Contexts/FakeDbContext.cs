using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Source.Repositories.Contexts;

public class FakeDbContext
{
    public static List<Tweet> Tweets { get; set; } = new()
    {
        new Tweet { Id=Guid.NewGuid(),User="New User",Content="C" },
        new Tweet {  Id=Guid.NewGuid(),User="New User",Content="C++" },
        new Tweet { Id=Guid.NewGuid(),User="New User",Content="C#" }
    };
}