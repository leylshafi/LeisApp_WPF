using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ServerDbContext _context;

        public UserController(ServerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _context.Users
                .Include(u=>u.Person)
                .Include(u=>u.Tweets)
                .Include(u=>u.Replies)
                .Include(u=>u.Likes)
                .ToListAsync());
        }

        [HttpPost("addTweet")]
        public async Task<ActionResult<Tweet>> AddTweet(MainTweetDto tweet)
        {
            var newTweet = new Tweet
            {
                Content= tweet.Content,
                Id= tweet.Id,
                UserId= Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")
            };

            await _context.Tweets.AddAsync(newTweet);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            if (user == null)
                return BadRequest();

            var newUser = user;

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return Ok(newUser);
        }
    }
}
