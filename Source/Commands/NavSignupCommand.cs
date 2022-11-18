using Source.Stores;
using Source.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Commands
{
    class NavSignUp : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavSignUp(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new SignUpViewModel();
        }
    }
}