using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Source.Models;

namespace Source.ViewModels
{
    class ProfileViewerViewModel:ViewModelBase
    {
        public User User { get; set; }
        public List<Tweet> UserTweets { get; set; }
        public static ObservableCollection<Tweet>? Tweets { get; set; }


        private Tweet? _tweet;

        public Tweet? SelectedTweet
        {
            get { return _tweet; }
            set
            {
                _tweet = value;
                OnPropertyChanged(nameof(SelectedTweet));
            }
        }

        public ICommand EditCommand { get; set; }
        public ProfileViewerViewModel(User user)
        {
            User = user;
            UserTweets = user.Tweets.ToList();
            if (User != null)
            {
                Tweets = new();
                for (int i = 0; i < UserTweets?.Count; i++)
                {
                    Tweets.Add(UserTweets[i]);
                    SelectedTweet = Tweets[i];
                }
            }
        }


    }
}
