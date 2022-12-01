using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using server.Models.Dtos;
using Source.Commands;
using Source.Models;
using Source.Stores;
using Source.Views;
using Source.Views.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Source.ViewModels
{
    class SignUpViewModel : ViewModelBase
    {
        public UserDto _user;

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private SecureString _password;
        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

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
            // https://localhost:7143/api/Users/register
            HttpClient client = new HttpClient();

            _user = new();
            _user.Username = Username;
            _user.Password = SecureStringToString(Password);
            _user.FirstName = Name;
            _user.LastName = Surname;

            var response = await client.PostAsJsonAsync("https://localhost:7143/api/Users/register", _user);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("SignUp Successfull");

                SignInWindow(obj);
            }

        }

        private string SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
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
