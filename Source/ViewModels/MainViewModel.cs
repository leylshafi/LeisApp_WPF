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
using System.Windows.Input;

namespace Source.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public static User User { get; set; }
        public static List<Tweet> UserTweets { get; set; }
        public static List<User> AllUsers { get; set; }

        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public ICommand GoProfileCommand { get; }
        public ICommand GoHomeCommand { get; }
        public ICommand GoExploreCommand { get; }

        public ICommand TweetCommand { get; }

        public MainViewModel(NavigationStore navigationStore, User user)
        {
            User = user;
            SyncTweets();

            GoProfileCommand = new NavProfileCommand(navigationStore);
            GoHomeCommand = new NavHomeCommand(navigationStore);
            GoExploreCommand = new NavExploreCommand(navigationStore);
            TweetCommand = new TweetCommand(User);

            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModel = new HomeViewModel();
            _navigationStore.CurrentViewModelChanged += _navigationStore_CurrentViewModelChanged;
        }

        public async static void SyncTweets()
        {
            HttpClient client= new HttpClient();
            string usersString = await client.GetStringAsync("https://localhost:7143/api/Users");
            AllUsers = JsonConvert.DeserializeObject<List<User>>(usersString);
            UserTweets = new();
            foreach (var tweet in User.Tweets)
            {
                UserTweets.Add(tweet);
            }
        }

        private void _navigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
