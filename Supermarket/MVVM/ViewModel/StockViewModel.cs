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
    public class StockViewModel : Core.ViewModel
    {
        private readonly StockBLL _stockBLL;

        private readonly ProductBLL _productBLL;
        public ObservableCollection<Stock> Stocks
        {
            get { return _stockBLL.Stocks; }
            set
            {
                _stockBLL.Stocks = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Product> Products
        {
            get { return _productBLL.Products; }
            set
            {
                _productBLL.Products = value;
                OnPropertyChanged();
            }
        }

        private Stock _selectedStock;
        public Stock SelectedStock
        {
            get { return _selectedStock; }
            set
            {
                _selectedStock = value;
                if (_selectedStock == null)
                {
                    return;
                }
                SelectedProduct = _selectedStock.Product;
                Quantity = _selectedStock.Quantity;
                UnitOfMeasurement = _selectedStock.UnitOfMeasurement;
                SupplyDate = _selectedStock.SupplyDate;
                ExpirationDate = _selectedStock.ExpirationDate;
                AcquisitionPrice = _selectedStock.AcquisitionPrice;
                SalePrice = _selectedStock.SalePrice;
                OnPropertyChanged("SelectedProduct");
                OnPropertyChanged("Product");
                OnPropertyChanged("Quantity");
                OnPropertyChanged("UnitOfMeasurement");
                OnPropertyChanged("SupplyDate");
                OnPropertyChanged("ExpirationDate");
                OnPropertyChanged("AcquisitionPrice");
                OnPropertyChanged("SalePrice");
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
                OnPropertyChanged();
            }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }

        private string _unitOfMeasurement;

        public string UnitOfMeasurement
        {
            get { return _unitOfMeasurement; }
            set
            {
                _unitOfMeasurement = value;
                OnPropertyChanged();
            }
        }

        private DateTime _supplyDate;

        public DateTime SupplyDate
        {
            get { return _supplyDate; }
            set
            {
                _supplyDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _expirationDate;

        public DateTime? ExpirationDate
        {
            get { return _expirationDate; }
            set
            {
                _expirationDate = value;
                OnPropertyChanged();
            }
        }

        private decimal _acquisitionPrice;

        public decimal AcquisitionPrice
        {
            get { return _acquisitionPrice; }
            set
            {
                _acquisitionPrice = value;
                OnPropertyChanged();
            }
        }

        private decimal _salePrice;

        public decimal SalePrice
        {
            get { return _salePrice; }
            set
            {
                _salePrice = value;
                OnPropertyChanged();
            }
        }

        public StockViewModel(StockBLL stockBLL, ProductBLL productBLL)
        {
            _stockBLL = stockBLL;
            _productBLL = productBLL;

            Stocks = _stockBLL.Stocks;
            Products = _productBLL.Products;

            SelectedProduct = Products.FirstOrDefault();
            SelectedStock = Stocks.FirstOrDefault();

            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            UpdateCommand = new RelayCommand(Update);
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        private void Add(object obj)
        {
            Stock stock = new Stock
            {
                Product = SelectedProduct,
                Quantity = Quantity,
                UnitOfMeasurement = UnitOfMeasurement,
                SupplyDate = SupplyDate,
                ExpirationDate = ExpirationDate,
                AcquisitionPrice = AcquisitionPrice,
                SalePrice = SalePrice
            };

            _stockBLL.Add(stock);
            Stocks = _stockBLL.Stocks;
        }

        private void Remove(object obj)
        {
            _stockBLL.Remove(SelectedStock);
            Stocks = _stockBLL.Stocks;
        }

        private void Update(object obj)
        {
            _stockBLL.Update(SelectedStock, SelectedProduct, Quantity, UnitOfMeasurement, SupplyDate, ExpirationDate, AcquisitionPrice, SalePrice);
            Stocks = _stockBLL.Stocks;
        }


    }
}
