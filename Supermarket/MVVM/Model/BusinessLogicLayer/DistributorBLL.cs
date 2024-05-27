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
        private SupermarketDBContext db = new SupermarketDBContext();
        public ObservableCollection<Distributor> Distributors {
            get { return TrueGetAll(); }
            set
            {
                Distributors = value;
            }
        }
        public string ErrorMessage { get; set; }

        public DistributorBLL()
        {
            Distributors = new ObservableCollection<Distributor>();
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
                    db.Distributors.Add(distributor);
                    db.SaveChanges();
                    //distributor.id = db.Distributors.Max(d => d.id);
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
                db.SaveChanges();
            }
        }

        public void Update(object obj)
        {
            Distributor distributor = obj as Distributor;
            if (distributor != null)
            {
                Distributor distributorToUpdate = db.Distributors.SingleOrDefault(d => d.Id == distributor.Id);
                if (distributorToUpdate != null)
                {
                    distributorToUpdate.Name = distributor.Name;
                    distributorToUpdate.Country = distributor.Country;
                    distributorToUpdate.IsActive = distributor.IsActive;
                    db.SaveChanges();
                }
            }
        }

        public ObservableCollection<Distributor> GetAll()
        {
            return new ObservableCollection<Distributor>(db.Distributors.Where(d => d.IsActive == true));
        }

        public ObservableCollection<Distributor> TrueGetAll()
        {
            return new ObservableCollection<Distributor>(db.Distributors);
        }
    }
}
