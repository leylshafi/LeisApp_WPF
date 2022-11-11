using Source.Stores;
using Source.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Commands
{
    class NavHomeCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavHomeCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel();
        }
    }
}
