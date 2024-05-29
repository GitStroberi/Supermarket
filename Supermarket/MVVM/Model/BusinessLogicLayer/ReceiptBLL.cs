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
        private SupermarketDBContext _db;

        private ObservableCollection<Receipt> _receipts;
        public ObservableCollection<Receipt> Receipts
        {
            get { return _receipts; }
            set
            {
                _receipts = value;
            }
        }

        public string ErrorMessage { get; set; }

        public ReceiptBLL(SupermarketDBContext db)
        {
            _db = db;
            Receipts = TrueGetAll();
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
                    _db.Users.Attach(receipt.Cashier);
                    _db.Receipts.Add(receipt);

                    _db.SaveChanges();
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
                _db.SaveChanges();
            }
        }

        public void Update(object obj)
        {
            Receipt receipt = obj as Receipt;
            if (receipt != null)
            {
                Receipt receiptToUpdate = _db.Receipts.SingleOrDefault(r => r.Id == receipt.Id);
                if (receiptToUpdate != null)
                {
                    receiptToUpdate.Cashier = receipt.Cashier;
                    receiptToUpdate.ReleaseDate = receipt.ReleaseDate;
                    receiptToUpdate.Value = receipt.Value;
                    receiptToUpdate.IsActive = receipt.IsActive;
                    _db.SaveChanges();
                }
            }
        }

        private ObservableCollection<Receipt> TrueGetAll()
        {
            return new ObservableCollection<Receipt>(_db.Receipts);
        }

        private ObservableCollection<Receipt> GetAll()
        {
            return new ObservableCollection<Receipt>(_db.Receipts.Where(r => r.IsActive == true));
        }
    }
}
