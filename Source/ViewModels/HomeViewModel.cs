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

namespace Source.ViewModels;

class HomeViewModel:ViewModelBase
{
    public ObservableCollection<Tweet>? Tweets { get; set; }

    public HomeViewModel()
    {
        Tweets = new();
        for (int i = 0; i < FakeDbContext.Tweets.Count; i++)
        {
            Tweets.Add(FakeDbContext.Tweets[i]);
        }
    }


}
