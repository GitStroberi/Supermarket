using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class CategoryBLL
    {
        private readonly SupermarketDBContext _db = new SupermarketDBContext();

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
            }
        }

        public string ErrorMessage { get; set; }

        public CategoryBLL(SupermarketDBContext db)
        {
            _db = db;
            Categories = TrueGetAll();
        }

        public void Add(object obj)
        {
            Category category = obj as Category;
            if (category != null)
            {
                if (string.IsNullOrEmpty(category.Name))
                {
                    ErrorMessage = "Name is required";
                }
                else
                {
                    _db.Categories.Add(category);
                    _db.SaveChanges();
                    //category.id = _db.Categories.Max(c => c.id);
                    Categories.Add(category);
                    ErrorMessage = "";
                }
            }
        }

        public void Remove(object obj)
        {
            Category category = obj as Category;
            if (category != null)
            {
                //set is_active to false
                category.IsActive = false;
                _db.SaveChanges();
            }
        }

        public void Update(object obj, string name)
        {
            Category category = obj as Category;
            if (category != null)
            {
                if (string.IsNullOrEmpty(category.Name))
                {
                    ErrorMessage = "Name is required";
                }
                else
                {
                    category.Name = name;
                    _db.SaveChanges();
                    ErrorMessage = "";
                }
            }
        }

        public ObservableCollection<Category> GetAll()
        {
            return new ObservableCollection<Category>(_db.Categories.Where(c => c.IsActive == true).ToList());
        }

        public ObservableCollection<Category> TrueGetAll()
        {
            return new ObservableCollection<Category>(_db.Categories.ToList());
        }
    }
}
