using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Supermarket.Core;
using Supermarket.MVVM.Model;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.Services;

namespace Supermarket.MVVM.ViewModel
{
    public class LoginViewModel : Core.ViewModel
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

        public string ErrorMessage
        {
            get { return _userBLL.ErrorMessage; }
            set
            {
                _userBLL.ErrorMessage = value;
                OnPropertyChanged();
            }
        }

        private INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get { return _navigationService; }
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command Members

        public RelayCommand LoginCommand { get; }
        public RelayCommand RegisterCommand { get; }

        public RelayCommand OpenRegisterPopupCommand { get; }
        #endregion

        public LoginViewModel(INavigationService navigationService, UserBLL userBLL)
        {
            _userBLL = userBLL;
            Users = _userBLL.GetAll();

            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);


            NavigationService = navigationService;
        }

        private void Login(object obj)
        {
            //validate the user input 

            if (string.IsNullOrEmpty(Username))
            {
                ErrorMessage = "Username is required";
            }
            else if (string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Password is required";
            }
            else
            {
                //check if the user exists
                User user = _userBLL.Authenticate(Username, Password);
                if (user != null)
                {
                    App.MainVM.CurrentUser = user;
                    //navigate to the home page
                    NavigationService.NavigateTo<HomeViewModel>();
                }
                else
                {
                    ErrorMessage = "Invalid username or password";
                }
            }
        }

        private void Register(object obj)
        {
            //navigate to the register page
            NavigationService.NavigateTo<RegisterViewModel>();
        }
    }
}
