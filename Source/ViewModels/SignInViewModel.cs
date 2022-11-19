using Source.Stores;
using Source.Views.Abstract;
using Source.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.ViewModels
{
    class SignInViewModel:ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public GalaSoft.MvvmLight.Command.RelayCommand<IClosable> SignUpCommand { get; private set; }



        public SignInViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            SignUpCommand = new GalaSoft.MvvmLight.Command.RelayCommand<IClosable>(this.SignUpWindow);
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
