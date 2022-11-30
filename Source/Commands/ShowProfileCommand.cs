using Source.Models;
using Source.ViewModels;
using Source.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Commands
{
    class ShowProfileCommand : CommandBase
    {
        private User _user;
        public override void Execute(object? parameter)
        {
            var view = new ProfileViewerView();
            view.DataContext = new ProfileViewerViewModel(_user);
            view.ShowDialog();
        }

        public ShowProfileCommand(int id)
        {
            _user = HomeViewModel.AllUsers.FirstOrDefault(u => u.Id == id);
        }
    }
}
