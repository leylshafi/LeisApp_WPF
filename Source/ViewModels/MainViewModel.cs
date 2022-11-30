using Newtonsoft.Json;
using Source.Commands;
using Source.Models;
using Source.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Reflection;
using System.Collections.ObjectModel;

namespace Source.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private string _username;

        public string username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(username));
            }
        }

        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public ObservableCollection<User> SelectedUsers { get; set; }
        public static User User { get; set; }
        public static List<Tweet> UserTweets { get; set; }
        public static List<User> AllUsers { get; set; }

        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public ICommand GoProfileCommand { get; }
        public ICommand GoHomeCommand { get; }
        public ICommand GoExploreCommand { get; }

        public ICommand TweetCommand { get; }
        public ICommand SearchCommand { get; }

        List<User> users;
        public MainViewModel(NavigationStore navigationStore, User user)
        {
            SelectedUsers = new();
            User = user;
            SyncTweets();
           
            GoProfileCommand = new NavProfileCommand(navigationStore);
            GoHomeCommand = new NavHomeCommand(navigationStore);
            TweetCommand = new TweetCommand(User);
            SearchCommand = new RelayCommand(ExecuteSearchCommand);

            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModel = new HomeViewModel();
            _navigationStore.CurrentViewModelChanged += _navigationStore_CurrentViewModelChanged;
        }

        private void ExecuteSearchCommand(object? obj)
        {
            SelectedUsers.Clear();
            
            string search = Content;
            foreach (User item in HomeViewModel.AllUsers)
            {
                if(item.Username.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    SelectedUsers.Add(item);
                    username= item.Username;
                }
            }
            Content = String.Empty;

        }

        public async static void SyncTweets()
        {
            HttpClient client= new HttpClient();
            string usersString = client.GetStringAsync("https://localhost:7143/api/Users").Result;
            AllUsers = JsonConvert.DeserializeObject<List<User>>(usersString);
            UserTweets = new();
            foreach (var tweet in User.Tweets)
            {
                tweet.User = User;
                UserTweets.Add(tweet);
            }
        }

        private void _navigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


    }
}
