using System.Collections.ObjectModel;
using System.Windows.Input;
using Source.Models;
using Source.Commands;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System;

namespace Source.ViewModels
{

    class HomeViewModel : ViewModelBase
    {
        public static ObservableCollection<Tweet>? Tweets { get; set; }
        public ICommand SetImageCommand { get; set; }
        public ICommand ShowProfileCommand { get; set; }

        public User? User { get; set; }
        public List<Tweet>? UserTweets { get; set; }
        public static List<User>? AllUsers { get; set; }

        private string? _imagePath;

        public string? ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public ICommand ReloadCommand { get; set; }

        public HomeViewModel()
        {
            Load();
        }

        private void Load()
        {
            User = MainViewModel.User;
            AllUsers = MainViewModel.AllUsers;
            UserTweets = new();
            var exUser = new User();
            ReloadCommand = new GalaSoft.MvvmLight.Command.RelayCommand(this.ReloadMethod);

            if (User != null)
            {
                if (AllUsers != null)
                {
                    foreach (var item in User.Following)
                    {
                        exUser = AllUsers.Find(u => u.Id == item.Fid);
                        if (exUser != null)
                        {
                            foreach (var tweet in exUser.Tweets)
                            {
                                tweet.User = exUser;
                                UserTweets.Add(tweet);
                            }
                        }
                    }
                }
                Tweets = new();
                for (int i = 0; i < UserTweets?.Count; i++)
                {
                    Tweets.Add(UserTweets[i]);
                    Tweets[i].ShowCommand = new ShowTweetCommand(Tweets[i]);
                    Tweets[i].ShowProfileCommand = new ShowProfileCommand(Tweets[i].UserId);
                    Tweets[i].LikeTweetCommand = new LikeTweetCommand(Tweets[i].Id,i);
                }

                ImagePath = string.Empty;
            }
        }

        private void ReloadMethod()
        {
            Load();
        }
    }
}
