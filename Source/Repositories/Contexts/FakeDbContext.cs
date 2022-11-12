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
    public static List<User> Users { get; set; } = new()
    {
        new User { Name="Leyla", Surname="Shafiyeva"},
        new User { Name="Isa", Surname="Mammadli" },
        new User { Name="Nigar", Surname="Shafiyeva"}
    };
    public static List<Tweet> Tweets { get; set; } = new()
    {
        new Tweet { Id=Guid.NewGuid(), User=Users[0],Username="NewUser",Content="C" ,Date=DateTime.Now},
        new Tweet {  Id=Guid.NewGuid(), User=Users[1],Username="NewUser",Content="C++" ,Date=DateTime.Now},
        new Tweet { Id=Guid.NewGuid(), User=Users[2],Username="NewUser",Content="C#" ,Date=DateTime.Now},
        new Tweet { Id=Guid.NewGuid(), User=Users[1],Username="NewUser",Content="C#" ,Date=DateTime.Now},
        new Tweet { Id=Guid.NewGuid(), User=Users[0],Username="NewUser",Content="C#" ,Date=DateTime.Now}
    };
}