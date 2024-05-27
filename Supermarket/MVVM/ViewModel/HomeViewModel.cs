using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Core;
using Supermarket.MVVM.Model;

namespace Supermarket.MVVM.ViewModel
{
    public class HomeViewModel : Core.ViewModel
    {
        public RelayCommand CheckPrivilegeCommand { get; }
        public HomeViewModel() { 
            CheckPrivilegeCommand = new RelayCommand(CheckPrivilege);
        }

        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        //testing logging in 
        //string for logged in as admin

        private string _loggedIn;
        public string LoggedIn
        {
            get { return _loggedIn; }
            set
            {
                _loggedIn = value;
                OnPropertyChanged();
            }
        }


        public void CheckPrivilege(object obj)
        {
            if (User.IsAdmin == true)
            {
                LoggedIn = "Logged in as Admin";
            }
            else
            {
                LoggedIn = "Logged in as User";
            }
        }
    }
}
