using Source.Models;
using Source.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Source.Commands
{
    class LikeTweetCommand : CommandBase
    {
        private int _id;
        private int _index;
        private Tweet _tweet;
        public async override void Execute(object? parameter)
        {
            HttpClient client = new HttpClient();
            var request = await client.PutAsJsonAsync($"https://localhost:7143/api/Users/like?tweetId={_id}", _id);
            if (request.IsSuccessStatusCode)
            {
                HomeViewModel.Tweets[_index].LikesCount += 1;
            }
        }

        public LikeTweetCommand(int id,int index)
        {
            _id = id;
            _index = index;
        }
    }
}
