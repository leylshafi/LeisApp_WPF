using GalaSoft.MvvmLight.CommandWpf;
using Source.Stores;
using Source.ViewModels;
using Source.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Source.Commands
{
    class ExampleCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        //private readonly Action<object> _execute;
        public ExampleCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }


        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel();

            MainView view = new();
            view.DataContext = new MainViewModel(_navigationStore,null);
            view.ShowDialog();
        }
    }
}
