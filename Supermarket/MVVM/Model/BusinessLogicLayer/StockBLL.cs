using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class StockBLL
    {
        private SupermarketDBContext db = new SupermarketDBContext();

        public ObservableCollection<Stock> Stocks
        {
            get { return TrueGetAll(); }
            set
            {
                Stocks = value;
            }
        }
        public string ErrorMessage { get; set; }

        public void Add(object obj)
        {
            Stock stock = obj as Stock;
            if (stock != null)
            {
                if (stock.Product == null)
                {
                    ErrorMessage = "Product is required";
                }
                else if (stock.Quantity == null)
                {
                    ErrorMessage = "Quantity is required";
                }
                else if (stock.SalePrice == null)
                {
                    ErrorMessage = "Price is required";
                }
                else
                {
                    db.Products.Attach(stock.Product);
                    db.Stocks.Add(stock);
                    db.SaveChanges();
                    ErrorMessage = "";
                }
            }
        }

        public void Remove(object obj)
        {
            Stock stock = obj as Stock;
            if (stock != null)
            {
                //set is_active to false
                stock.IsActive = false;
                db.SaveChanges();
            }
        }

        public void Update(object obj)
        {
            Stock stock = obj as Stock;
            if (stock != null)
            {
                Stock stockToUpdate = db.Stocks.SingleOrDefault(s => s.Id == stock.Id);
                if (stockToUpdate != null)
                {
                    stockToUpdate.Product = stock.Product;
                    stockToUpdate.Quantity = stock.Quantity;
                    stockToUpdate.UnitOfMeasurement = stock.UnitOfMeasurement;
                    stockToUpdate.SupplyDate = stock.SupplyDate;
                    stockToUpdate.ExpirationDate = stock.ExpirationDate;
                    stockToUpdate.SalePrice = stock.SalePrice;
                    stockToUpdate.IsActive = stock.IsActive;
                    db.SaveChanges();
                }
            }
        }

        public ObservableCollection<Stock> TrueGetAll()
        {
            return new ObservableCollection<Stock>(db.Stocks);
        }

        public ObservableCollection<Stock> GetAll()
        {
            return new ObservableCollection<Stock>(db.Stocks.Where(s => s.IsActive == true));
        }
    }
}
