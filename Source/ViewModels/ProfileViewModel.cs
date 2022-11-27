using Microsoft.Win32;
using Source.Commands;
using Source.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Source.ViewModels
{
    class ProfileViewModel : ViewModelBase
    {
        private string? _imagePath;

        public string? ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }


        private string? _backgroundPath;

        public string? BackgroundPath
        {
            get { return _backgroundPath; }
            set
            {
                _backgroundPath = value;
                OnPropertyChanged(nameof(BackgroundPath));
            }
        }

        public User User { get; set; }

        public ICommand EditCommand { get; set; }
        public ProfileViewModel()
        {
            User = MainViewModel.User;
            ImagePath = "StaticFiles/img/user.png";
            BackgroundPath = "StaticFiles/img/background.png";
            EditCommand = new RelayCommand(EditExecuteCommand, EditCanExecuteCommand);
        }

        private bool EditCanExecuteCommand(object? obj) => true;

        private void EditExecuteCommand(object? obj)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "img files (*.img)|*.png|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == true)
            {

                string filePath = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                StreamReader sr = new StreamReader(filePath);
                ImagePath = filePath;
                User.ProfilePicture = filePath;
               
            }
           var result= MessageBox.Show("Do you want to add background image?","Question",MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (openFileDialog1.ShowDialog() == true)
                {

                    string filePath = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                    StreamReader sr = new StreamReader(filePath);
                    BackgroundPath = filePath;
                }
            }
            else return;

        }
    }
}
