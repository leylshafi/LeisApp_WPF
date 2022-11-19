using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Models.Dtos;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ServerDbContext _context;

        public UsersController(ServerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _context.Users
                .Include(u=>u.Tweets)
                .Include(u=>u.Following)
                .Include(u=>u.Followers)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(UserDto user)
        {
            var newUser = new User {
                Username = user.Username,
                FirstName=user.FirstName,
                LastName=user.LastName,
                BirthDate=user.BirthDate
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return Ok(newUser);
        }


        // Tweets

        [HttpGet("tweets")]
        public async Task<ActionResult<List<Tweet>>> GetTweets()
        {
            return Ok(await _context.Tweets
                .Include(t=>t.Comments)
                .ToListAsync());
        }

        [HttpPost("addTweet")]
        public async Task<ActionResult<Tweet>> AddTweet(TweetDto tweet)
        {
            var newTweet = new Tweet
            {
                Id=tweet.Id,
                Content = tweet.Content,
                Created = tweet.Created,
                UserId = tweet.UserId
            };

            await _context.Tweets.AddAsync(newTweet);
            await _context.SaveChangesAsync();
            return Ok(newTweet);
        }

        // Comments

        [HttpGet("comments")]
        public async Task<ActionResult<List<Comment>>> GetComments()
        {
            return Ok(await _context.Comments.ToListAsync());
        }

        [HttpPost("addComment")]
        public async Task<ActionResult<Tweet>> AddComment(CommentDto comment)
        {
            var newComment = new Comment
            {
                Id = comment.Id,
                Content= comment.Content,
                Created = comment.Created,
                ReplingTo= comment.ReplingTo,
                TweetId=comment.TweetId
            };

            await _context.Comments.AddAsync(newComment);
            await _context.SaveChangesAsync();
            return Ok(newComment);
        }

    }
}
