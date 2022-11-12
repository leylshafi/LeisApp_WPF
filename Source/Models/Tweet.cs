using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Models
{
    class Tweet
    {
        public Guid Id { get; set; }
        // string will has been User
        public string User { get; set; }
        public string Content { get; set; }
    }
}
