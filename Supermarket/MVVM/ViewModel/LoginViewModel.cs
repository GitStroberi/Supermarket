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
    public class LoginViewModel : Core.ViewModel
    {
        private UserBLL userBLL;

        #region Data Members
        public ObservableCollection<User> Users
        {
            get { return userBLL.Users; }
            set
            {
                userBLL.Users = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return userBLL.ErrorMessage; }
            set
            {
                userBLL.ErrorMessage = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command Members

        private void AddTestUser(object obj)
        {
            User user = new User();
            user.username = "admin";
            user.password = "admin";
            user.is_admin = true;
            userBLL.Add(user);
        }

        public RelayCommand AddTestUserCommand => new RelayCommand(AddTestUser);

        #endregion

        public LoginViewModel()
        {
            userBLL = new UserBLL();
            Users = userBLL.GetAll();
        }
    }
}
