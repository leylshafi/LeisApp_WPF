using Source.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Source.Models;
using Source.Repositories;
using Source.Repositories.Contexts;
using Source.Commands;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.Win32;
using Source.Views.UserControls;
using System.ComponentModel;

namespace Source.ViewModels;

class HomeViewModel : ViewModelBase
{
    public ObservableCollection<Tweet>? Tweets { get; set; }
    public ICommand SetImageCommand { get; set; }




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
        Tweets = new();
        for (int i = 0; i < FakeDbContext.Tweets.Count; i++)
        {
            Tweets.Add(FakeDbContext.Tweets[i]);
            SelectedTweet = Tweets[i];
        }
        SetImageCommand = new RelayCommand(ExecuteShowCommand, CanExecuteCommand);
        ImagePath = String.Empty;
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
            ImagePath= filePath;
        }
    }

}
