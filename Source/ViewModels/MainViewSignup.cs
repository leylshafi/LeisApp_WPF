using Source.Commands;
using Source.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Source.ViewModels
{
    class MainViewSignup : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        //public ICommand GoSigninCommand { get; }

        public MainViewSignup(NavigationStore navigationStore)
        {
            //GoSigninCommand = new NavProfileCommand(navigationStore);

            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModel = new SignUpViewModel();
            _navigationStore.CurrentViewModelChanged += _navigationStore_CurrentViewModelChanged;
        }

        private void _navigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
