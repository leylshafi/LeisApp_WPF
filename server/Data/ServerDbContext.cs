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
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<ReTweet> Replies { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Following> Following { get; set; }
        public DbSet<Comment> Comments { get; set;}
    }
}
