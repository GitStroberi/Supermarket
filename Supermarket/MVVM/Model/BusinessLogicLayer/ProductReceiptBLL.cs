using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class ProductReceiptBLL
    {
        private SupermarketDBContext db = new SupermarketDBContext();

        public ObservableCollection<ProductReceipt> ProductReceipts { 
            get { return TrueGetAll(); }
            set
            {
                ProductReceipts = value;
            }
        }
        public string ErrorMessage { get; set; }

        public ProductReceiptBLL()
        {
        }

        public void Add(object obj)
        {
            ProductReceipt productReceipt = obj as ProductReceipt;
            if (productReceipt != null)
            {
                if (productReceipt.Product == null)
                {
                    ErrorMessage = "Product is required";
                }
                else if (productReceipt.Receipt == null)
                {
                    ErrorMessage = "Receipt is required";
                }
                else if (productReceipt.Quantity <= 0)
                {
                    ErrorMessage = "Quantity must be greater than 0";
                }
                else
                {
                    db.Products.Attach(productReceipt.Product);
                    db.Receipts.Attach(productReceipt.Receipt);
                    db.ProductReceipts.Add(productReceipt);

                    db.SaveChanges();
                    ErrorMessage = "";
                }
            }
        }

        public void Remove(object obj)
        {
            ProductReceipt productReceipt = obj as ProductReceipt;
            if (productReceipt != null)
            {
                //set is_active to false
                productReceipt.IsActive = false;
                db.SaveChanges();
            }
        }

        public void Update(object obj)
        {
            ProductReceipt productReceipt = obj as ProductReceipt;
            if (productReceipt != null)
            {
                if (productReceipt.Product == null)
                {
                    ErrorMessage = "Product is required";
                }
                else if (productReceipt.Receipt == null)
                {
                    ErrorMessage = "Receipt is required";
                }
                else if (productReceipt.Quantity <= 0)
                {
                    ErrorMessage = "Quantity must be greater than 0";
                }
                else
                {
                    db.Products.Attach(productReceipt.Product);
                    db.Receipts.Attach(productReceipt.Receipt);
                    
                    //product receipt is a composite key
                    ProductReceipt productReceiptToUpdate = db.ProductReceipts.SingleOrDefault(pr => pr.ProductId == productReceipt.ProductId && pr.ReceiptId == productReceipt.ReceiptId);
                    if (productReceiptToUpdate != null)
                    {
                        productReceiptToUpdate.Quantity = productReceipt.Quantity;
                        productReceiptToUpdate.IsActive = productReceipt.IsActive;
                        db.SaveChanges();
                    }
                }
            }
        }

        private ObservableCollection<ProductReceipt> TrueGetAll()
        {
            return new ObservableCollection<ProductReceipt>(db.ProductReceipts);
        }

        private ObservableCollection<ProductReceipt> GetAll()
        {
            return new ObservableCollection<ProductReceipt>(db.ProductReceipts.Where(pr => pr.IsActive == true));
        }
    }
}
