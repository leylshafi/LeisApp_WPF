using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.CommandWpf;
using Source.Commands;
using Source.Stores;
using Source.Views;
using Source.Views.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Source.ViewModels
{
    class SignUpViewModel: ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public GalaSoft.MvvmLight.Command.RelayCommand<IClosable> SignInCommand { get; private set; }



        public SignUpViewModel(NavigationStore navigationStore)
        {
            _navigationStore= navigationStore;
            SignInCommand = new GalaSoft.MvvmLight.Command.RelayCommand<IClosable>(this.SignInWindow);
        }

        private void SignInWindow(IClosable obj)
        {
            _navigationStore.CurrentViewModel = new SignInViewModel(_navigationStore);
            SignInView mainView = new();
            mainView.DataContext = new SignInViewModel(_navigationStore);
            mainView.Show();
            if (obj != null)
            {
                obj.Close();
            }
        }
    }
}
