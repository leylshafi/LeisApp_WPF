using Source.Models;
using Source.ViewModels;
using Source.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Commands
{
    internal class TweetCommand : CommandBase
    {
        public User User { get; set; }
        public TweetCommand(User user)
        {
            User = user;
        }

        public override void Execute(object? parameter)
        {
            AddTweetView view = new AddTweetView();
            view.DataContext = new AddTweetViewModel(User);
            view.ShowDialog();
        }
    }
}
