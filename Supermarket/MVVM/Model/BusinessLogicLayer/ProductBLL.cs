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

        public ObservableCollection<Product> Products { get; set; }

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

        public void Update(object obj)
        {
            Product product = obj as Product;

            if (product != null)
            {
                Product productToUpdate = db.Products.SingleOrDefault(p => p.Id == product.Id);
                Category category = db.Categories.SingleOrDefault(c => c.Id == product.Category.Id);
                Distributor distributor = db.Distributors.SingleOrDefault(d => d.Id == product.Distributor.Id);

                if (productToUpdate != null)
                {
                    productToUpdate.Name = product.Name;
                    productToUpdate.Barcode = product.Barcode;
                    productToUpdate.Category = category;
                    productToUpdate.Distributor = distributor;
                    productToUpdate.IsActive = product.IsActive;
                    db.SaveChanges();
                }
            }
        }
    }
}
