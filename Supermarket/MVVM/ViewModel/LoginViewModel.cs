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

        private CategoryBLL categoryBLL;

        private DistributorBLL distributorBLL;

        private ProductBLL productBLL;

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
            // test if category, distributor, and product work
            categoryBLL = new CategoryBLL();
            distributorBLL = new DistributorBLL();
            productBLL = new ProductBLL();

            Category category = new Category { Name = "Test Category" };
            
            Distributor distributor = new Distributor { Name = "Test Distributor", Country = "Test Country" };

            Product product = new Product { Name = "Test Product", Barcode="111111", Category=category, Distributor=distributor };
            productBLL.Add(product);
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
