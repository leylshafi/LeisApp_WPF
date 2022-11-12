using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class ServerDbContext:DbContext
    {
        public ServerDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Like> Likes { get; set; }

    }
}
