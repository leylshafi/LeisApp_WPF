using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.Data;
using server.Models;
using server.Models.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ServerDbContext _context;
        private readonly IConfiguration _config;

        public UsersController(ServerDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("user")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            List<User> users = await _context.Users
                .Include(u => u.Tweets)
                .Include(u => u.Following)
                .Include(u => u.Followers)
                .ToListAsync();

            var user = users.Where(u => u.Username == username);
            if (user == null)
                return NotFound();

            var result = user.ToList()[0];

            return Ok(user.ToList()[0]);
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

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = new User()
            {
                Username = request.Username,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                FirstName = request.FirstName,
                LastName= request.LastName,
                BirthDate = request.BirthDate,
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u=>u.Username==request.Username);

            if (existingUser == null)
            {
                return BadRequest("User don't found");
            }

            if (!VerifyPasswordHash(request.Password, existingUser.PasswordHash, existingUser.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }

            string token = CreateToken(existingUser);
            return Ok(token);
        }

        private string CreateToken(User user)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Username),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);


            return jwt;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            };
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            };
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

        [HttpPut("like")]
        public async Task<ActionResult<User>> AddLike(int tweetId)
        {
            var tweet = await _context.Tweets.FindAsync(tweetId);
            tweet.LikesCount += 1;

            _context.Tweets.Update(tweet);
            await _context.SaveChangesAsync();
            return Ok(tweet);
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

        // Follow

        [HttpPost("follow")]

        public async Task<ActionResult> Follow(int userId,int followId)
        {
            var newFollower = new Follower
            {
                Fid = followId,
                UserId= userId,
            };

            var newFollowing = new Following
            {
                Fid = userId,
                UserId = followId,
            };

            await _context.Followers.AddAsync(newFollower);
            await _context.Following.AddAsync(newFollowing);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
