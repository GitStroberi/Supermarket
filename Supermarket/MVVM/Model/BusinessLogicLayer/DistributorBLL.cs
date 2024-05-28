using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class DistributorBLL
    {
        private readonly SupermarketDBContext _db = new SupermarketDBContext();
        
        private ObservableCollection<Distributor> _distributors;
        public ObservableCollection<Distributor> Distributors
        {
            get { return _distributors; }
            set
            {
                _distributors = value;
            }
        }
        public string ErrorMessage { get; set; }

        public DistributorBLL(SupermarketDBContext db)
        {
            _db = db;
            Distributors = TrueGetAll();
        }

        public void Add(object obj)
        {
            Distributor distributor = obj as Distributor;
            if (distributor != null)
            {
                if (string.IsNullOrEmpty(distributor.Name))
                {
                    ErrorMessage = "Name is required";
                }
                else if (string.IsNullOrEmpty(distributor.Country))
                {
                    ErrorMessage = "Country is required";
                }
                else
                {
                    _db.Distributors.Add(distributor);
                    _db.SaveChanges();
                    //distributor.Id = _db.Distributors.Max(d => d.Id);
                    Distributors.Add(distributor);
                    ErrorMessage = "";
                }
            }
        }

        public void Remove(object obj)
        {
            Distributor distributor = obj as Distributor;
            if (distributor != null)
            {
                //set is_active to false
                distributor.IsActive = false;
                _db.SaveChanges();
            }
        }

        public void Update(object obj, string name, string country)
        {
            Distributor distributor = obj as Distributor;
            if (distributor != null)
            {
                if (string.IsNullOrEmpty(name))
                {
                    ErrorMessage = "Name is required";
                }
                else if (string.IsNullOrEmpty(country))
                {
                    ErrorMessage = "Country is required";
                }
                else
                {
                    distributor.Name = name;
                    distributor.Country = country;
                    _db.SaveChanges();
                    ErrorMessage = "";
                }
            }
        }

        public ObservableCollection<Distributor> GetAll()
        {
            return new ObservableCollection<Distributor>(_db.Distributors.Where(d => d.IsActive == true));
        }

        public ObservableCollection<Distributor> TrueGetAll()
        {
            return new ObservableCollection<Distributor>(_db.Distributors);
        }
    }
}
