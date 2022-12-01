using Source.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Source.Commands
{
    internal class FollowUserCommand : CommandBase
    {
        private int _userId;
        private int _followId;
        private string _text;
        public async override void Execute(object? parameter)
        {
            //https://localhost:7143/api/Users/follow?userId=5&followId=1
            HttpClient client = new();
            HttpResponseMessage? request;
            if (_text == "Follow")
                request = await client.PostAsJsonAsync($"https://localhost:7143/api/Users/follow?userId={_userId}&followId={_followId}", _userId);
            else
                request = await client.DeleteAsync($"https://localhost:7143/api/Users/deletefollow?userId={_userId}&followId={_followId}");
        }

        public FollowUserCommand(int userId, int followId,ref string text)
        {
            _userId = userId;
            _followId = followId;
            _text = text;
        }
    }
}
