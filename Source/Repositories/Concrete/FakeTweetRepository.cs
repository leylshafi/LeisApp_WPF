using Source.Models;
using Source.Repositories.Abstract;
using Source.Repositories.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Source.Repositories.Concrete;

public class FakeTweetRepository : ITweetRepository
{
    public void Add(Tweet entity) => FakeDbContext.Tweets.Add(entity);
    public Tweet? Get(Func<Tweet, bool> predicate) => FakeDbContext.Tweets.FirstOrDefault(predicate);

    public IList<Tweet>? GetList(Func<Tweet, bool>? predicate = null)
    => (predicate is null) switch
    {
        true => FakeDbContext.Tweets,
        false => FakeDbContext.Tweets.Where(predicate).ToList(),
    };

    public void Remove(Tweet entity)
        => FakeDbContext.Tweets.Remove(entity);

    public void Update(Tweet entity)
    {
        var index = FakeDbContext.Tweets.IndexOf(entity);
        FakeDbContext.Tweets[index] = entity;
    }
}