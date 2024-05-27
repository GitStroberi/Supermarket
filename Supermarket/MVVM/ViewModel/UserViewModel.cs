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
        private UserBLL userBLL;

        #region Data Members
        public ObservableCollection<User> Users {
            get { return userBLL.GetAll(); }
            set
            {
                userBLL.Users = value;
                OnPropertyChanged();
            }
        }
        public User SelectedUser { get; set; }
        
        #endregion

        #region Commands

        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        #endregion

        public UserViewModel()
        {
            userBLL = new UserBLL();

            Users = new ObservableCollection<User>(userBLL.GetAll());

            SelectedUser = Users.FirstOrDefault();

            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            UpdateCommand = new RelayCommand(Update);
        }

        private void Add(object obj)
        {
            userBLL.Add(SelectedUser);
            Users = new ObservableCollection<User>(userBLL.GetAll());
        }

        private void Remove(object obj)
        {
            userBLL.Remove(SelectedUser);
            Users = new ObservableCollection<User>(userBLL.GetAll());
        }

        private void Update(object obj)
        {
            userBLL.Update(SelectedUser);
            Users = new ObservableCollection<User>(userBLL.GetAll());
        }
    }
}
