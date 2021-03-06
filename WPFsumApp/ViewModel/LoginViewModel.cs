﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Prism.Commands;
using WPFsumApp.Common.Controllers;
using WPFsumApp.Common.Models;

namespace WPFsumApp.ViewModel
{
    [Export]
    public class LoginViewModel : INotifyPropertyChanged
    {
        private bool _visible;
        private bool _isLoggedIn;
        private UserController _userController;

        [ImportingConstructor]
        public LoginViewModel(
            UserController userController)
        {
            _userController = userController ?? throw new ArgumentNullException(nameof(userController));

            IsLoggedIn = false;

            UsersListProperty = new List<User>()
            {
                new User { ID = 1, Name = "Béla1", Description = "valami1" },
                new User { ID = 2, Name = "Béla2", Description = "valami2" },
                new User { ID = 3, Name = "Béla3", Description = "valami3" }
            };

            _visible = false;

            LoginButtonCommand = new DelegateCommand(LoginButtonCommandExecute);
            ExitButtonCommand = new DelegateCommand(ExitButtonCommandExecute);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoginButtonCommand { get; set; }

        public ICommand ExitButtonCommand { get; set; }

        public User LoggedInUser { get; set; }

        public bool IsLoggedIn
        {
            get
            {
                return _isLoggedIn;
            }

            set
            {
                _isLoggedIn = value;
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public List<User> UsersListProperty
        {
            get;
            set;
        }

        public bool Visible
        {
            get
            {
                return _visible;
            }

            set
            {
                _visible = value;
                OnPropertyChanged(nameof(Visible));
            }
        }

        public bool IsRegisteredUserID(int id)
        {
            if (id == 1 || id == 3)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void LoginButtonCommandExecute()
        {
            IsLoggedIn = true;
            _userController.ActualUser = LoggedInUser;
        }

        private void ExitButtonCommandExecute()
        {
            IsLoggedIn = false;
            _userController.ActualUser = null;
        }
    }
}
