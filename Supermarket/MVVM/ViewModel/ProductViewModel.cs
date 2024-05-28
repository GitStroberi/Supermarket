using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.MVVM.Model;
using Supermarket.MVVM.Model.BusinessLogicLayer;

namespace Supermarket.MVVM.ViewModel
{
    public class ProductViewModel : Core.ViewModel
    {
        private ProductBLL productBLL;
        private CategoryBLL categoryBLL;
        private DistributorBLL distributorBLL;

        public ObservableCollection<Product> Products
        {
            get { return productBLL.Products; }
            set
            {
                productBLL.Products = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Category> Categories
        {
            get { return categoryBLL.Categories; }
            set
            {
                categoryBLL.Categories = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Distributor> Distributors
        {
            get { return distributorBLL.Distributors; }
            set
            {
                distributorBLL.Distributors = value;
                OnPropertyChanged();
            }
        }

        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public Category SelectedCategory
        {
            get { return _selectedProduct.Category; }
            set
            {
                _selectedProduct.Category = value;
                OnPropertyChanged();
            }
        }

        public Distributor SelectedDistributor
        {
            get { return _selectedProduct.Distributor; }
            set
            {
                _selectedProduct.Distributor = value;
                OnPropertyChanged();
            }
        }

        public ProductViewModel()
        {
            productBLL = new ProductBLL();
            categoryBLL = new CategoryBLL();
            distributorBLL = new DistributorBLL();

            Products = new ObservableCollection<Product>(productBLL.Products);
            Categories = new ObservableCollection<Category>(categoryBLL.Categories);
            Distributors = new ObservableCollection<Distributor>(distributorBLL.Distributors);
        }

        public string ErrorMessage
        {
            get { return productBLL.ErrorMessage; }
            set
            {
                productBLL.ErrorMessage = value;
                OnPropertyChanged();
            }
        }
        
        public void AddProduct()
        {
            productBLL.Add(SelectedProduct);
            Products = new ObservableCollection<Product>(productBLL.TrueGetAll());
        }

    }
}
