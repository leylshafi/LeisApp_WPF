using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.ViewModels
{
    class ProfileViewModel : ViewModelBase
    {
        public User User { get; set; }
        public ProfileViewModel()
        {
            User = MainViewModel.User;
        }
    }
}
