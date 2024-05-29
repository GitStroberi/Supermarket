using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Core;
using Supermarket.MVVM.Model;
using Supermarket.MVVM.Model.BusinessLogicLayer;

namespace Supermarket.MVVM.ViewModel
{
    public class UserViewModel : Core.ViewModel
    {
        private readonly UserBLL _userBLL;

        #region Data Members
        public ObservableCollection<User> Users {
            get { return _userBLL.Users; }
            set
            {
                _userBLL.Users = value;
                OnPropertyChanged();
            }
        }
        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                if (_selectedUser == null)
                {
                    return;
                }
                Username = _selectedUser.Username;
                Password = _selectedUser.Password;
                IsAdmin = _selectedUser.IsAdmin;
                OnPropertyChanged("Username");
                OnPropertyChanged("Password");
                OnPropertyChanged("IsAdmin");
                OnPropertyChanged();
            }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return _userBLL.ErrorMessage; }
            set
            {
                _userBLL.ErrorMessage = value;
                OnPropertyChanged();
            }
        }
        
        #endregion

        #region Commands

        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        #endregion

        public UserViewModel(UserBLL userBLL)
        {
            _userBLL = userBLL;

            Users = _userBLL.Users;

            SelectedUser = Users.FirstOrDefault();

            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            UpdateCommand = new RelayCommand(Update);
        }

        private void Add(object obj)
        {
            User user = new User
            {
                Username = Username,
                Password = Password,
                IsAdmin = IsAdmin
            };
            _userBLL.Add(user);
            Users = _userBLL.Users;
            ErrorMessage = _userBLL.ErrorMessage;
        }

        private void Remove(object obj)
        {
            _userBLL.Remove(SelectedUser);
            Users = _userBLL.Users;
            ErrorMessage = _userBLL.ErrorMessage;
        }

        private void Update(object obj)
        {
            _userBLL.Update(SelectedUser, Username, Password, IsAdmin);
            Users = _userBLL.Users;
            ErrorMessage = _userBLL.ErrorMessage;
        }
    }
}
