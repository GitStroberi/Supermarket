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
        public ObservableCollection<Distributor> Distributors { get; set; }
        public string ErrorMessage { get; set; }

        public void Add(object obj)
        {
            Distributor distributor = obj as Distributor;
            if (distributor != null)
            {
                if (string.IsNullOrEmpty(distributor.name))
                {
                    ErrorMessage = "Name is required";
                }
                else if (string.IsNullOrEmpty(distributor.country))
                {
                    ErrorMessage = "Country is required";
                }
                else
                {
                    db.Distributors.Add(distributor);
                    db.SaveChanges();
                    distributor.id = db.Distributors.Max(d => d.id);
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
                distributor.is_active = false;
                db.SaveChanges();
            }
        }

        public void Update(object obj)
        {
            Distributor distributor = obj as Distributor;
            if (distributor != null)
            {
                Distributor distributorToUpdate = db.Distributors.SingleOrDefault(d => d.id == distributor.id);
                if (distributorToUpdate != null)
                {
                    distributorToUpdate.name = distributor.name;
                    distributorToUpdate.country = distributor.country;
                    distributorToUpdate.is_active = distributor.is_active;
                    db.SaveChanges();
                }
            }
        }
    }
}
