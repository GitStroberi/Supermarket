using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Core;
using Supermarket.MVVM.Model;
using Supermarket.MVVM.Model.BusinessLogicLayer;

namespace Supermarket.MVVM.ViewModel
{
    public class DistributorViewModel : Core.ViewModel
    {
        private readonly DistributorBLL _distributorBLL;
        public ObservableCollection<Distributor> Distributors
        {
            get { return _distributorBLL.Distributors; }
            set
            {
                _distributorBLL.Distributors = value;
                OnPropertyChanged();
            }
        }

        private Distributor _selectedDistributor;
        public Distributor SelectedDistributor { 
            get { return _selectedDistributor; }
            set
            {
                _selectedDistributor = value;
                if(_selectedDistributor == null)
                {
                    return;
                }
                Name = _selectedDistributor.Name;
                Country = _selectedDistributor.Country;
                OnPropertyChanged("Name");
                OnPropertyChanged("Country");
                OnPropertyChanged();
            }
        }

        private string _name;
        
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged();
            }
        }

        #region Commands

        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        #endregion

        public DistributorViewModel(DistributorBLL distributorBLL)
        {
            _distributorBLL = distributorBLL;

            Distributors = _distributorBLL.Distributors;

            SelectedDistributor = Distributors.FirstOrDefault();

            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            UpdateCommand = new RelayCommand(Update);
        }

        private void Add(object obj)
        {
            Distributor distributor = new Distributor()
            {
                Name = Name,
                Country = Country
            };
            _distributorBLL.Add(distributor);
            Distributors = _distributorBLL.Distributors;
        }

        private void Remove(object obj)
        {
            _distributorBLL.Remove(SelectedDistributor);
            Distributors = _distributorBLL.Distributors;
        }

        private void Update(object obj)
        {
            _distributorBLL.Update(SelectedDistributor, Name, Country);
            Distributors = _distributorBLL.Distributors;
        }
    }
}
