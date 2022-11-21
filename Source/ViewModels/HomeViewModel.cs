using System.Collections.ObjectModel;
using System.Windows.Input;
using Source.Models;
using Source.Commands;
using System.IO;
using Microsoft.Win32;
using System.Net.Http;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System;
using System.Windows;

namespace Source.ViewModels;

class HomeViewModel : ViewModelBase
{
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


    public ObservableCollection<Tweet>? Tweets { get; set; }
    public ICommand SetImageCommand { get; set; }
    public ICommand AddCommand { get; set; }

    public User? User { get; set; }
    public List<Tweet>? UserTweets { get; set; }



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

    public HomeViewModel()
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
        AddCommand = new RelayCommand(AddExecuteCommand, AddCanExecuteCommand);
    }

    private bool AddCanExecuteCommand(object? obj)
    {
        return true;
    }

    private void AddExecuteCommand(object? obj)
    {
        Tweets?.Insert(0,new Tweet()
        {
            Content= Content,
            Created=DateTime.Now,
            User=User,
        });
        Content=String.Empty;


    }

    bool CanExecuteCommand(object? parametr) => true;

    void ExecuteShowCommand(object? parametr)
    {

        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        openFileDialog1.Filter = "img files (*.img)|*.png|All files (*.*)|*.*";

        if (openFileDialog1.ShowDialog() == true)
        {

            string filePath = System.IO.Path.GetFullPath(openFileDialog1.FileName);
            StreamReader sr = new StreamReader(filePath);
            ImagePath = filePath;
        }
    }

}
