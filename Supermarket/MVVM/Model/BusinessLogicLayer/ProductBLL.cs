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
        private SupermarketDBContext db = new SupermarketDBContext();

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

        public ProductBLL()
        {
            Products = new ObservableCollection<Product>();
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
                    db.Categories.Attach(product.Category);
                    db.Distributors.Attach(product.Distributor);
                    db.Products.Add(product);

                    db.SaveChanges();
                    //product.id = db.Products.Max(p => p.id);
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
                db.SaveChanges();
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
                    db.SaveChanges();
                    ErrorMessage = "";
                }
            }
        }

        public ObservableCollection<Product> TrueGetAll()
        {
            return new ObservableCollection<Product>(db.Products);
        }

        public ObservableCollection<Product> GetAll()
        {
            return new ObservableCollection<Product>(db.Products.Where(p => p.IsActive == true));
        }
    }
}
