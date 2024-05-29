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
                if (_selectedProduct == null)
                {
                    return;
                }
                Name = _selectedProduct.Name;
                Barcode = _selectedProduct.Barcode;
                SelectedCategory = _selectedProduct.Category;
                SelectedDistributor = _selectedProduct.Distributor;
                OnPropertyChanged("Name");
                OnPropertyChanged("Barcode");
                OnPropertyChanged();
            }
        }

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }

        private Distributor _selectedDistributor;
        public Distributor SelectedDistributor
        {
            get { return _selectedDistributor; }
            set
            {
                _selectedDistributor = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _barcode;

        public string Barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        public ProductViewModel(ProductBLL productBLL, CategoryBLL categoryBLL, DistributorBLL distributorBLL)
        {
            _productBLL = productBLL;
            _categoryBLL = categoryBLL;
            _distributorBLL = distributorBLL;

            Products = _productBLL.Products;
            Categories = _categoryBLL.Categories;
            Distributors = _distributorBLL.Distributors;

            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            UpdateCommand = new RelayCommand(Update);

            SelectedProduct = Products.FirstOrDefault();
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

        private void Add(object obj)
        {
            Product product = new Product
            {
                Name = Name,
                Barcode = Barcode,
                Category = SelectedCategory,
                Distributor = SelectedDistributor
            };

            _productBLL.Add(product);
            Products = _productBLL.Products;
            ErrorMessage = _productBLL.ErrorMessage;
        }

        private void Remove(object obj)
        {
            _productBLL.Remove(SelectedProduct);
            Products = _productBLL.Products;
            ErrorMessage = _productBLL.ErrorMessage;
        }

        private void Update(object obj)
        {
            _productBLL.Update(SelectedProduct, Name, Barcode, SelectedCategory, SelectedDistributor);
            Products = _productBLL.Products;
            ErrorMessage = _productBLL.ErrorMessage;
        }
    }
}
