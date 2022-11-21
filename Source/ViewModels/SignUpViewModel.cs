using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Source.Commands;
using Source.Models;
using Source.Stores;
using Source.Views;
using Source.Views.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Source.ViewModels
{
    class SignUpViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public GalaSoft.MvvmLight.Command.RelayCommand<IClosable> SignInCommand { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand<IClosable> SubmitCommand { get; private set; }



        public SignUpViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            SignInCommand = new GalaSoft.MvvmLight.Command.RelayCommand<IClosable>(this.SignInWindow);
            SubmitCommand = new GalaSoft.MvvmLight.Command.RelayCommand<IClosable>(this.SignUpSumbit);
        }

        private async void SignUpSumbit(IClosable obj)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7143/api/Users");
            var userString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<List<User>>(userString);

            _navigationStore.CurrentViewModel = new MainViewModel(_navigationStore, user[0]);
            MainView mainView = new();
            mainView.DataContext = new MainViewModel(_navigationStore, user[0]);

            if (obj != null)
            {
                obj.Close();
            }
            mainView.Show();

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
