using Source.Models;
using Source.Stores;
using Source.ViewModels;
using Source.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Commands
{
    class ShowTweetCommand : CommandBase
    {
        private Tweet _tweet;
        public override void Execute(object? parameter)
        {
            ShowTweetView view = new();
            view.DataContext = new ShowTweetViewModel(_tweet);
            view.ShowDialog();
        }

        public ShowTweetCommand(Tweet tweet)
        {
            _tweet = tweet;
        }
    }
}
