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
using Source.Commands;
using Source.Views.Abstract;
using System.Net.Http;
using System.Windows.Media;

namespace Source.ViewModels
{
    class ProfileViewerViewModel : ViewModelBase
    {
        public static User User { get; set; }
        public List<Tweet> UserTweets { get; set; }
        public static ObservableCollection<Tweet>? Tweets { get; set; }

        private string? _text;
        public string? Text
        {
            get { return _text; }
            set
             {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

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
        public GalaSoft.MvvmLight.Command.RelayCommand<IClosable> FollowCommand { get; set; }
        public ProfileViewerViewModel(User user)
        {
            User = user;

            UserTweets = user.Tweets.ToList();
            FollowUnFollow();

            FollowCommand = new GalaSoft.MvvmLight.Command.RelayCommand<IClosable>(this.FollowSubmit);

            if (User != null)
            {
                Tweets = new();
                for (int i = 0; i < UserTweets?.Count; i++)
                {
                    Tweets.Add(UserTweets[i]);
                    SelectedTweet = Tweets[i];
                    SelectedTweet.ForeColor = Brushes.White;
                }
            }
        }


        private async void FollowSubmit(IClosable obj)
        {
            HttpClient client = new();
            HttpResponseMessage? request;
            if (_text == "Follow")
            {
                request = await client.PostAsJsonAsync($"https://localhost:7143/api/Users/follow?userId={MainViewModel.User.Id}&followId={User.Id}", User.Id);
                if (request.IsSuccessStatusCode)
                {
                    var follower = new Follower()
                    {
                        Fid = MainViewModel.User.Id,
                        UserId = User.Id,
                    };
                    User.Followers.Add(follower);
                    var following = new Following()
                    {
                        Fid = User.Id,
                        UserId = MainViewModel.User.Id,
                    };
                    MainViewModel.User.Following.Add(following);
                }
            }
            else
            {
                request = await client.DeleteAsync($"https://localhost:7143/api/Users/deletefollow?userId={MainViewModel.User.Id}&followId={User.Id}");
                if (request.IsSuccessStatusCode)
                {
                    var follower = User.Followers.Find(f => f.UserId == User.Id);
                    if (follower != null)
                        User.Followers.Remove(follower);
                    var following = MainViewModel.User.Following.Find(f=>f.Fid == User.Id);
                    MainViewModel.User.Following.Remove(following);
                }
            }
            FollowUnFollow();
        }

        public void FollowUnFollow()
        {
            if (User.Followers.Count > 0)
                foreach (var item in User.Followers)
                {
                    if (item.Fid == MainViewModel.User.Id)
                    {
                        Text = "UnFollow";
                        break;
                    }
                    Text = "Follow";
                }
            else Text = "Follow";
        }


    }
}
