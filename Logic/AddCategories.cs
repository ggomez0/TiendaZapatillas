using TiendaZapatillas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaZapatillas.Logic
{
    public class AddCategories
    {
        public bool AddCategory(string CategoryName)
        {
            var myCategory = new Category();
            myCategory.CategoryName = CategoryName;
           

            using (ProductContext _db = new ProductContext())
            {
                // Add product to DB.
                _db.Categories.Add(myCategory);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }

        public bool AddGenCat(string GeneroCategoryName)
        {
            var myCategory = new GeneroCategory();
            myCategory.GeneroName = GeneroCategoryName;


            using (ProductContext _db = new ProductContext())
            {
                // Add product to DB.
                _db.GeneroCategories.Add(myCategory);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }

   


    }
}