using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore.Metadata;
using Supermarket.Core;
using Supermarket.MVVM.Model;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.Services;

namespace Supermarket.MVVM.ViewModel
{
    public class RegisterViewModel : Core.ViewModel
    {
        private readonly UserBLL _userBLL;

        #region Data Members
        public ObservableCollection<User> Users
        {
            get { return _userBLL.Users; }
            set
            {
                _userBLL.Users = value;
                OnPropertyChanged();
            }
        }

        private string _registerUsername;
        public string RegisterUsername
        {
            get { return _registerUsername; }
            set
            {
                _registerUsername = value;
                OnPropertyChanged();
            }
        }

        private string _registerPassword;
        public string RegisterPassword
        {
            get { return _registerPassword; }
            set
            {
                _registerPassword = value;
                OnPropertyChanged();
            }
        }

        private string _registerConfirmPassword;
        public string RegisterConfirmPassword
        {
            get { return _registerConfirmPassword; }
            set
            {
                _registerConfirmPassword = value;
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
        #endregion

        #region Command Members
        public RelayCommand RegisterCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }

        #endregion

        INavigationService NavigationService { get; set; }

        public RegisterViewModel(INavigationService navigationService, UserBLL userBLL)
        {
            _userBLL = userBLL;
            Users = _userBLL.GetAll();

            RegisterCommand = new RelayCommand(Register);
            CancelCommand = new RelayCommand(Cancel);

            NavigationService = navigationService;
        }

        public void Register(object obj)
        {
            if (RegisterPassword != RegisterConfirmPassword)
            {
                MessageBox.Show("Passwords do not match");
            }
            else
            {
                User user = new User
                {
                    Username = RegisterUsername,
                    Password = RegisterPassword,
                    IsAdmin = IsAdmin
                };

                _userBLL.Add(user);
                Users = _userBLL.GetAll();
            }
        }

        public void Cancel(object obj)
        {
            //Navigate to login view

            NavigationService.NavigateTo<LoginViewModel>();
        }
    }
}
