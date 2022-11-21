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

        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public ICommand GoProfileCommand { get; }
        public ICommand GoHomeCommand { get; }
        public ICommand GoExploreCommand { get; }

        public ICommand TweetCommand { get; }

        public MainViewModel(NavigationStore navigationStore, User user)
        {
            User = user;
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:7143/api/Users/tweets");
            var tweetString = response.Result.Content.ReadAsStringAsync();
            UserTweets = JsonConvert.DeserializeObject<List<Tweet>>(tweetString.Result);
            UserTweets.ForEach(t => t.User = User);

            GoProfileCommand = new NavProfileCommand(navigationStore);
            GoHomeCommand = new NavHomeCommand(navigationStore);
            GoExploreCommand = new NavExploreCommand(navigationStore);
            TweetCommand = new TweetCommand(User);

            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModel = new HomeViewModel();
            _navigationStore.CurrentViewModelChanged += _navigationStore_CurrentViewModelChanged;
        }

        private void _navigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
