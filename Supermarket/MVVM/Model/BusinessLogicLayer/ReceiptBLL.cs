using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class ReceiptBLL
    {
        private SupermarketDBContext db = new SupermarketDBContext();

        public ObservableCollection<Receipt> Receipts { get; set; }

        public string ErrorMessage { get; set; }

        public ReceiptBLL()
        {
            Receipts = new ObservableCollection<Receipt>();
        }

        public void Add(object obj)
        {
            Receipt receipt = obj as Receipt;
            if (receipt != null)
            {
                if (receipt.Cashier == null)
                {
                    ErrorMessage = "Cashier is required";
                }
                else if (receipt.ReleaseDate == null)
                {
                    ErrorMessage = "ReleaseDate is required";
                }
                else
                {
                    db.Users.Attach(receipt.Cashier);
                    db.Receipts.Add(receipt);

                    db.SaveChanges();
                    Receipts.Add(receipt);
                    ErrorMessage = "";
                }
            }
        }

        public void Remove(object obj)
        {
            Receipt receipt = obj as Receipt;
            if (receipt != null)
            {
                //set is_active to false
                receipt.IsActive = false;
                db.SaveChanges();
            }
        }

        public void Update(object obj)
        {
            Receipt receipt = obj as Receipt;
            if (receipt != null)
            {
                Receipt receiptToUpdate = db.Receipts.SingleOrDefault(r => r.Id == receipt.Id);
                if (receiptToUpdate != null)
                {
                    receiptToUpdate.Cashier = receipt.Cashier;
                    receiptToUpdate.ReleaseDate = receipt.ReleaseDate;
                    receiptToUpdate.Value = receipt.Value;
                    receiptToUpdate.IsActive = receipt.IsActive;
                    db.SaveChanges();
                }
            }
        }
    }
}
