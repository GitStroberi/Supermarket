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
        private readonly CategoryBLL _categoryBLL;

        public ObservableCollection<Category> Categories
        {
            get { return _categoryBLL.Categories; }
            set
            {
                _categoryBLL.Categories = value;
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

        public CategoryViewModel(CategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;

            Categories = _categoryBLL.Categories;

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
            _categoryBLL.Add(category);
            Categories = _categoryBLL.Categories;
        }

        public void Remove(object obj)
        {
            _categoryBLL.Remove(SelectedCategory);
            Categories = _categoryBLL.Categories;
        }

        public void Update(object obj)
        {
            _categoryBLL.Update(SelectedCategory, Name);
            Categories = _categoryBLL.Categories;
        }
        
    }
}
