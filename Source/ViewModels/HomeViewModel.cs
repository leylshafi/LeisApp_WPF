using System.Collections.ObjectModel;
using System.Windows.Input;
using Source.Models;
using Source.Commands;
using System.IO;
using Microsoft.Win32;

namespace Source.ViewModels;

class HomeViewModel : ViewModelBase
{
    public ObservableCollection<Tweet>? Tweets { get; set; }
    public ICommand SetImageCommand { get; set; }

    public User User { get; set; }



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
        if (User != null)
        {

            Tweets = new();
            for (int i = 0; i < User.Tweets.Count; i++)
            {
                Tweets.Add(User.Tweets[i]);
                SelectedTweet = Tweets[i];
            }

            SetImageCommand = new RelayCommand(ExecuteShowCommand, CanExecuteCommand);
            ImagePath = string.Empty;
        }
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
