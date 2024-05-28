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
        private readonly SupermarketDBContext _db;

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
            }
        }
        public string ErrorMessage { get; set; }

        public UserBLL(SupermarketDBContext db)
        {
            _db = db;
            Users = TrueGetAll();
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
                    _db.Users.Add(user);
                    _db.SaveChanges();
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
                _db.SaveChanges();
            }
        }

        public void Update(object obj)
        {
            User user = obj as User;
            if (user != null)
            {
                User userToUpdate = _db.Users.SingleOrDefault(u => u.Id == user.Id);
                if (userToUpdate != null)
                {
                    userToUpdate.Username = user.Username;
                    userToUpdate.Password = user.Password;
                    userToUpdate.IsAdmin = user.IsAdmin;
                    _db.SaveChanges();
                }
            }
        }

        public User Authenticate(string username, string password)
        {
            User user = _db.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            return user;
        }

        public ObservableCollection<User> GetAll()
        {
            return new ObservableCollection<User>(_db.Users.Where(u => u.IsActive == true));
        }

        public ObservableCollection<User> TrueGetAll()
        {
            return new ObservableCollection<User>(_db.Users);
        }

        public User GetByUsername(string username)
        {
            User user = _db.Users.SingleOrDefault(u => u.Username == username);
            return user;
        }
    }
}
