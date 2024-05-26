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

        public ObservableCollection<Category> Categories { get; set; }

        public string ErrorMessage { get; set; }

        public void Add(object obj)
        {
            Category category = obj as Category;
            if (category != null)
            {
                if (string.IsNullOrEmpty(category.name))
                {
                    ErrorMessage = "Name is required";
                }
                else
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                    category.id = db.Categories.Max(c => c.id);
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
                category.is_active = false;
                db.SaveChanges();
            }
        }

        public void Update(object obj)
        {
            Category category = obj as Category;
            if (category != null)
            {
                Category categoryToUpdate = db.Categories.SingleOrDefault(c => c.id == category.id);
                if (categoryToUpdate != null)
                {
                    categoryToUpdate.name = category.name;
                    db.SaveChanges();
                }
            }
        }
    }
}
