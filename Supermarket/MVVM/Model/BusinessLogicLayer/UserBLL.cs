using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class UserBLL
    {
        private SupermarketDBContext db = new SupermarketDBContext();
        public ObservableCollection<User> Users { get; set; }
        public string ErrorMessage { get; set; }

        public UserBLL()
        {
            Users = new ObservableCollection<User>();
        }

        public void Add(object obj)
        {
            User user = obj as User;
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.Username))
                {
                    ErrorMessage = "Username is required";
                }
                else if (string.IsNullOrEmpty(user.Password))
                {
                    ErrorMessage = "Password is required";
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    //user.id = db.Users.Max(u => u.id);
                    Users.Add(user);
                    ErrorMessage = "";
                }
            }
        }

        public void Remove(object obj)
        {
            User user = obj as User;
            if (user != null)
            {
                //set is_active to false
                user.IsActive = false;
                db.SaveChanges();
            }
        }

        public void Update(object obj)
        {
            User user = obj as User;
            if (user != null)
            {
                User userToUpdate = db.Users.SingleOrDefault(u => u.Id == user.Id);
                if (userToUpdate != null)
                {
                    userToUpdate.Username = user.Username;
                    userToUpdate.Password = user.Password;
                    userToUpdate.IsAdmin = user.IsAdmin;
                    db.SaveChanges();
                }
            }
        }

        public ObservableCollection<User> GetAll()
        {
            Users = new ObservableCollection<User>(db.Users.Where(u => u.IsActive == true));
            return Users;
        }
    }
}
