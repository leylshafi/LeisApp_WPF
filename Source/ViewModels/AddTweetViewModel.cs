using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Source.Commands;
using Source.Models;
using Source.Models.Dtos;
using Source.Stores;
using Source.Views;
using Source.Views.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Source.ViewModels
{
    internal class AddTweetViewModel : ViewModelBase
    {
        private string _content;

        public User User { get; set; }
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));

            }
        }

        public RelayCommand<IClosable> SendTweetCommand { get; private set; }

        public AddTweetViewModel(User user)
        {
            User = user;
            SendTweetCommand = new RelayCommand<IClosable>(this.Sumbit);
        }

        private async void Sumbit(IClosable obj)
        {
            TweetDto newTweet = new TweetDto();
            newTweet.Content = Content;
            newTweet.Created = DateTime.Now;
            newTweet.UserId = User.Id;

            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync("https://localhost:7143/api/Users/addTweet", newTweet);
            if (response.IsSuccessStatusCode)
            {
                MainViewModel.SyncTweets();
                if (ProfileViewModel.Tweets != null)
                {
                    ProfileViewModel.Tweets.Add(MainViewModel.UserTweets.Last());

                }
                else
                {
                    ProfileViewModel.Tweets = new();
                    foreach (var item in MainViewModel.UserTweets)
                    {
                        ProfileViewModel.Tweets.Add(item);
                    }
                }

                if (obj != null)
                {
                    obj.Close();
                }
            }
        }
    }
}
