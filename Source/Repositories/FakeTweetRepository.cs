using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Repositories
{
    class FakeTweetRepository
    {
        static List<Tweet> Tweets = new()
        {
           new Tweet{Id=Guid.NewGuid(),Content="Hello C#",User="Isa"},
           new Tweet{Id=Guid.NewGuid(),Content="Hello C++",User="Leila"},
           new Tweet{Id=Guid.NewGuid(),Content="Hello Java",User="Kamo"},
        };
    }
}
