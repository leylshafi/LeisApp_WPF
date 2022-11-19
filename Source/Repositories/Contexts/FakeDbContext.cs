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
        new User { FirstName="Leyla", LastName="Shafiyeva"},
    };
    public static List<Tweet> Tweets { get; set; } = new()
    {
    };
}