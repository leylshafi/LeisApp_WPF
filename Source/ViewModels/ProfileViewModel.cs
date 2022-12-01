using Microsoft.Win32;
using Source.Commands;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Source.ViewModels
{
    class ProfileViewModel : ViewModelBase
    {
        private Brush? _foreColor;

        public Brush? ForeColor
        {
            get { return _foreColor; }
            set
            {
                _foreColor = value;
                OnPropertyChanged(nameof(ForeColor));
            }
        }

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

        private string? _backgroundPath;

        public string? BackgroundPath
        {
            get { return _backgroundPath; }
            set
            {
                _backgroundPath = value;
                OnPropertyChanged(nameof(BackgroundPath));
            }
        }


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
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ProfileViewModel()
        {
            User = MainViewModel.User;
            UserTweets = MainViewModel.UserTweets;
            if (User != null)
            {
                Tweets = new();
                for (int i = 0; i < UserTweets?.Count; i++)
                {
                    Tweets.Add(UserTweets[i]);
                    SelectedTweet = Tweets[i];
                }

                ImagePath = string.Empty;
            }
            ImagePath = "StaticFiles/img/user.png";
            BackgroundPath = "StaticFiles/img/background.png";
            EditCommand = new RelayCommand(EditExecuteCommand, EditCanExecuteCommand);
            AddCommand = new RelayCommand(AddExecuteCommand);
        }


        private void AddExecuteCommand(object? obj)
        {
            if (Content !=null && Content.Length>0 )
            {
                Tweets?.Insert(0, new Tweet()
                {
                    Content = Content,
                    Created = DateTime.Now,
                    User = User,
                });

                Content = String.Empty;
            }
        }

        private bool EditCanExecuteCommand(object? obj) => true;

        private void EditExecuteCommand(object? obj)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "img files (*.img)|*.png|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == true)
            {

                string filePath = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                StreamReader sr = new StreamReader(filePath);
                ImagePath = filePath;
                User.ProfilePicture = filePath;

            }
            var result = MessageBox.Show("Do you want to add background image?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (openFileDialog1.ShowDialog() == true)
                {

                    string filePath = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                    StreamReader sr = new StreamReader(filePath);
                    BackgroundPath = filePath;
                }
            }
            else return;

        }
    }
}
