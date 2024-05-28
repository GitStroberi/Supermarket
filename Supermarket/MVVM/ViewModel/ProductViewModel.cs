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
        private readonly ProductBLL _productBLL;
        private readonly CategoryBLL _categoryBLL;
        private readonly DistributorBLL _distributorBLL;

        public ObservableCollection<Product> Products
        {
            get { return _productBLL.Products; }
            set
            {
                _productBLL.Products = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Category> Categories
        {
            get { return _categoryBLL.Categories; }
            set
            {
                _categoryBLL.Categories = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Distributor> Distributors
        {
            get { return _distributorBLL.Distributors; }
            set
            {
                _distributorBLL.Distributors = value;
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

        public ProductViewModel(ProductBLL productBLL, CategoryBLL categoryBLL, DistributorBLL distributorBLL)
        {
            _productBLL = productBLL;
            _categoryBLL = categoryBLL;
            _distributorBLL = distributorBLL;

            Products = _productBLL.Products;
            Categories = _categoryBLL.Categories;
            Distributors = _distributorBLL.Distributors;
        }

        public string ErrorMessage
        {
            get { return _productBLL.ErrorMessage; }
            set
            {
                _productBLL.ErrorMessage = value;
                OnPropertyChanged();
            }
        }
        
        public void AddProduct()
        {
            _productBLL.Add(SelectedProduct);
            Products = new ObservableCollection<Product>(_productBLL.TrueGetAll());
        }

    }
}
