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
        public User SelectedUser { get; set; }
        
        #endregion

        #region Commands

        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        #endregion

        public UserViewModel(UserBLL userBLL)
        {
            _userBLL = userBLL;

            Users = userBLL.Users;

            SelectedUser = Users.FirstOrDefault();

            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            UpdateCommand = new RelayCommand(Update);
        }

        private void Add(object obj)
        {
            _userBLL.Add(SelectedUser);
            Users = _userBLL.Users;
        }

        private void Remove(object obj)
        {
            _userBLL.Remove(SelectedUser);
            Users = _userBLL.Users;
        }

        private void Update(object obj)
        {
            _userBLL.Update(SelectedUser);
            Users = _userBLL.Users;
        }
    }
}
