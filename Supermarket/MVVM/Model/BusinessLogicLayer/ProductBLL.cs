using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class ProductBLL
    {
        private readonly SupermarketDBContext _db;

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
            }
        }

        public string ErrorMessage { get; set; }

        public ProductBLL(SupermarketDBContext db)
        {
            _db = db;
            Products = TrueGetAll();
        }

        public void Add(object obj)
        {
            Product product = obj as Product;
            if (product != null)
            {
                if (string.IsNullOrEmpty(product.Name))
                {
                    ErrorMessage = "Name is required";
                }
                else if (product.Barcode == null)
                {
                    ErrorMessage = "Barcode is required";
                }
                else if (product.Category == null)
                {
                    ErrorMessage = "Category is required";
                }
                else if (product.Distributor == null)
                {
                    ErrorMessage = "Distributor is required";
                }
                else
                {
                    _db.Categories.Attach(product.Category);
                    _db.Distributors.Attach(product.Distributor);
                    _db.Products.Add(product);

                    _db.SaveChanges();
                    //product.id = _db.Products.Max(p => p.id);
                    Products.Add(product);
                    ErrorMessage = "";
                }
            }
        }

        public void Remove(object obj)
        {
            Product product = obj as Product;
            if (product != null)
            {
                //set is_active to false
                product.IsActive = false;
                _db.SaveChanges();
            }
        }

        public void Update(object obj, string name, string barcode, Category category, Distributor distributor)
        {
            Product product = obj as Product;
            if (product != null)
            {
                if (string.IsNullOrEmpty(name))
                {
                    ErrorMessage = "Name is required";
                }
                else if (barcode == null)
                {
                    ErrorMessage = "Barcode is required";
                }
                else
                {
                    product.Name = name;
                    product.Barcode = barcode;
                    product.Category = category;
                    product.Distributor = distributor;
                    _db.SaveChanges();
                    ErrorMessage = "";
                }
            }
        }

        public ObservableCollection<Product> TrueGetAll()
        {
            return new ObservableCollection<Product>(_db.Products);
        }

        public ObservableCollection<Product> GetAll()
        {
            return new ObservableCollection<Product>(_db.Products.Where(p => p.IsActive == true));
        }
    }
}
