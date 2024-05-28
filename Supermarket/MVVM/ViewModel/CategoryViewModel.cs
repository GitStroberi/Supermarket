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
    public class CategoryViewModel : Core.ViewModel
    {
        private CategoryBLL categoryBLL;

        public ObservableCollection<Category> Categories
        {
            get { return categoryBLL.Categories; }
            set
            {
                categoryBLL.Categories = value;
                OnPropertyChanged();
            }
        }

        private Category _selectedCategory;

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                if (_selectedCategory == null)
                {
                    return;
                }
                Name = _selectedCategory.Name;
                OnPropertyChanged("Name");
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

        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        public CategoryViewModel()
        {
            categoryBLL = new CategoryBLL();

            Categories = categoryBLL.Categories;

            SelectedCategory = Categories.FirstOrDefault();

            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            UpdateCommand = new RelayCommand(Update);
        }

        public void Add(object obj)
        {
            Category category = new Category()
            {
                Name = Name
            };
            categoryBLL.Add(category);
            Categories = categoryBLL.Categories;
        }

        public void Remove(object obj)
        {
            categoryBLL.Remove(SelectedCategory);
            Categories = categoryBLL.Categories;
        }

        public void Update(object obj)
        {
            categoryBLL.Update(SelectedCategory, Name);
            Categories = categoryBLL.Categories;
        }
        
    }
}
