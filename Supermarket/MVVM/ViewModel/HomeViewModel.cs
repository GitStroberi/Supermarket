using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.MVVM.Model;

namespace Supermarket.MVVM.ViewModel
{
    public class HomeViewModel : Core.ViewModel
    {
        public HomeViewModel() { }

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

        private string _adminLoggedIn;
        public string AdminLoggedIn
        {
            get { return _adminLoggedIn; }
            set
            {
                _adminLoggedIn = value;
                OnPropertyChanged();
            }
        }

        //string for logged in as user
        private string _userLoggedIn;
        public string UserLoggedIn
        {
            get { return _userLoggedIn; }
            set
            {
                _userLoggedIn = value;
                OnPropertyChanged();
            }
        }


    }
}
