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
        private SupermarketDBContext db = new SupermarketDBContext();

        public ObservableCollection<Category> Categories {
            get { return TrueGetAll(); }
            set
            {
                Categories = value;
            }
        }

        public string ErrorMessage { get; set; }

        public CategoryBLL()
        {
            Categories = new ObservableCollection<Category>();
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
                    db.Categories.Add(category);
                    db.SaveChanges();
                    //category.id = db.Categories.Max(c => c.id);
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
                db.SaveChanges();
            }
        }

        public void Update(object obj)
        {
            Category category = obj as Category;
            if (category != null)
            {
                Category categoryToUpdate = db.Categories.SingleOrDefault(c => c.Id == category.Id);
                if (categoryToUpdate != null)
                {
                    categoryToUpdate.Name = category.Name;
                    categoryToUpdate.IsActive = category.IsActive;
                    db.SaveChanges();
                }
            }
        }

        public ObservableCollection<Category> GetAll()
        {
            return new ObservableCollection<Category>(db.Categories.Where(c => c.IsActive == true).ToList());
        }

        public ObservableCollection<Category> TrueGetAll()
        {
            return new ObservableCollection<Category>(db.Categories.ToList());
        }
    }
}
