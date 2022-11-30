using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.ViewModels
{
    class ShowTweetViewModel
    {
        public Tweet Tweet { get; set; }
        public ShowTweetViewModel(Tweet tweet)
        {
            Tweet= tweet;
        }
    }
}
