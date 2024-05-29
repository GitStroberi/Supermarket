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
    public class ReceiptViewModel : Core.ViewModel
    {
        private readonly ReceiptBLL _receiptBLL;

        private readonly StockBLL _stockBLL;

        private readonly ProductBLL _productBLL;

        
        private ObservableCollection<ProductReceiptInfo> _productReceiptInfos;

        public ObservableCollection<ProductReceiptInfo> ProductReceiptInfos
        {
            get { return _productReceiptInfos; }
            set
            {
                _productReceiptInfos = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Receipt> _receipts;

        public ObservableCollection<Receipt> Receipts
        {
            get { return _receipts; }
            set
            {
                _receipts = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Stock> _stocks;

        public ObservableCollection<Stock> Stocks
        {
            get { return _stocks; }
            set
            {
                _stocks = value;
                OnPropertyChanged();
            }
        }

        private Receipt _selectedReceipt;

        public Receipt SelectedReceipt
        {
            get { return _selectedReceipt; }
            set
            {
                _selectedReceipt = value;
                if (_selectedReceipt == null)
                {
                    return;
                }
                ReleaseDate = _selectedReceipt.ReleaseDate;
                Cashier = _selectedReceipt.Cashier;
                Value = _selectedReceipt.Value;
                OnPropertyChanged("ReleaseDate");
                OnPropertyChanged("Cashier");
                OnPropertyChanged("Value");
                OnPropertyChanged();
            }
        }

        private DateTime _releaseDate;

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set
            {
                _releaseDate = value;
                OnPropertyChanged();
            }
        }

        private User _cashier;

        public User Cashier
        {
            get { return _cashier; }
            set
            {
                _cashier = value;
                OnPropertyChanged();
            }
        }

        private decimal _value;

        public decimal Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        public ReceiptViewModel(ReceiptBLL receiptBLL, StockBLL stockBLL, ProductBLL productBLL)
        {
            _receiptBLL = receiptBLL;
            _stockBLL = stockBLL;
            _productBLL = productBLL;

            Products = _productBLL.Products;
            Stocks = _stockBLL.Stocks;
            Receipts = _receiptBLL.Receipts;

            ProductReceiptInfos = new ObservableCollection<ProductReceiptInfo>();

            foreach (var receipt in Receipts)
            {
                foreach (var productReceipt in receipt.ProductReceipts)
                {
                    var stock = Stocks.FirstOrDefault(s => s.ProductId == productReceipt.ProductId);
                    if (stock != null)
                    {
                        ProductReceiptInfos.Add(new ProductReceiptInfo
                        {
                            ProductName = stock.Product.Name,
                            Quantity = productReceipt.Quantity,
                            Price = stock.SalePrice,
                            TotalPrice = productReceipt.Quantity * stock.SalePrice
                        });
                    }
                }
            }

            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            UpdateCommand = new RelayCommand(Update);
        }

        public string ErrorMessage
        {
            get { return _receiptBLL.ErrorMessage; }
            set
            {
                _receiptBLL.ErrorMessage = value;
                OnPropertyChanged();
            }
        }

        private void Add(object obj)
        {
            Receipt receipt = new Receipt
            {
                ReleaseDate = ReleaseDate,
                Cashier = Cashier,
                Value = Value
            };

            _receiptBLL.Add(receipt);
            if (string.IsNullOrEmpty(_receiptBLL.ErrorMessage))
            {
                Receipts.Add(receipt);
                ProductReceiptInfos.Clear();
                foreach (var productReceipt in receipt.ProductReceipts)
                {
                    var stock = Stocks.FirstOrDefault(s => s.ProductId == productReceipt.ProductId);
                    if (stock != null)
                    {
                        ProductReceiptInfos.Add(new ProductReceiptInfo
                        {
                            ProductName = stock.Product.Name,
                            Quantity = productReceipt.Quantity,
                            Price = stock.SalePrice,
                            TotalPrice = productReceipt.Quantity * stock.SalePrice
                        });
                    }
                }
            }
            ErrorMessage = _receiptBLL.ErrorMessage;
        }

        private void Remove(object obj)
        {
            _receiptBLL.Remove(SelectedReceipt);
            if (string.IsNullOrEmpty(_receiptBLL.ErrorMessage))
            {
                Receipts.Remove(SelectedReceipt);
                ProductReceiptInfos.Clear();
            }
            ErrorMessage = _receiptBLL.ErrorMessage;
        }

        private void Update(object obj)
        {
            Receipt receipt = new Receipt
            {
                Id = SelectedReceipt.Id,
                ReleaseDate = ReleaseDate,
                Cashier = Cashier,
                Value = Value
            };

            _receiptBLL.Update(receipt);
            if (string.IsNullOrEmpty(_receiptBLL.ErrorMessage))
            {
                var index = Receipts.IndexOf(SelectedReceipt);
                Receipts[index] = receipt;
                ProductReceiptInfos.Clear();
                foreach (var productReceipt in receipt.ProductReceipts)
                {
                    var stock = Stocks.FirstOrDefault(s => s.ProductId == productReceipt.ProductId);
                    if (stock != null)
                    {
                        ProductReceiptInfos.Add(new ProductReceiptInfo
                        {
                            ProductName = stock.Product.Name,
                            Quantity = productReceipt.Quantity,
                            Price = stock.SalePrice,
                            TotalPrice = productReceipt.Quantity * stock.SalePrice
                        });
                    }
                }
            }
            ErrorMessage = _receiptBLL.ErrorMessage;
        }
    }

    public class ProductReceiptInfo
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
