using Source.Stores;
using Source.Views.Abstract;
using Source.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.Models;
using server.Models.Dtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Windows;
using System.Windows.Media;
using System.Security;
using System.Runtime.InteropServices;


namespace Source.ViewModels
{
    class SignInViewModel : ViewModelBase
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

        private Brush _foregroundColor;
        public Brush foregroundColor
        {
            get => _foregroundColor;
            set
            {
                _foregroundColor = value;
                OnPropertyChanged(nameof(foregroundColor));
            }
        }
        



        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public GalaSoft.MvvmLight.Command.RelayCommand<IClosable> SignUpCommand { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand<IClosable> SubmitCommand { get; private set; }

        public SignInViewModel(NavigationStore navigationStore)
        {
            foregroundColor = Brushes.Transparent; 
            //_foregroundColor=Brushes.Transparent;
            _navigationStore = navigationStore;
            SignUpCommand = new GalaSoft.MvvmLight.Command.RelayCommand<IClosable>(this.SignUpWindow);
            SubmitCommand = new GalaSoft.MvvmLight.Command.RelayCommand<IClosable>(this.SignInSumbit);

        }

        private async void SignInSumbit(IClosable obj)
        {
            //https://localhost:7143/api/Users/login
            HttpClient client = new HttpClient();
            _user = new();
            _user.Username = Username;
            _user.Password = SecureStringToString(Password);
            _user.FirstName = string.Empty;
            _user.LastName = string.Empty;

            var response = await client.PostAsJsonAsync("https://localhost:7143/api/Users/login", _user);
            if (response.IsSuccessStatusCode)
            {
                var responseAll = await client.GetAsync($"https://localhost:7143/api/Users/user?username={_user.Username}");
                var userString = await responseAll.Content.ReadAsStringAsync();
                User user = JsonConvert.DeserializeObject<User>(userString);

                _navigationStore.CurrentViewModel = new MainViewModel(_navigationStore, user);
                MainView mainView = new();
                mainView.DataContext = new MainViewModel(_navigationStore, user);
                if (obj != null)
                {
                    obj.Close();
                }
                mainView.Show();
            }
            else
            {
                foregroundColor = Brushes.Blue;
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

        private void SignUpWindow(IClosable obj)
        {
            _navigationStore.CurrentViewModel = new SignUpViewModel(_navigationStore);
            SignUpView mainView = new SignUpView();
            mainView.DataContext = new SignUpViewModel(_navigationStore);
            mainView.Show();
            if (obj != null)
            {
                obj.Close();
            }
        }
    }
}
