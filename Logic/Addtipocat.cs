using TiendaZapatillas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaZapatillas.Logic
{
    public class AddTypeCategory
    {

        public bool AddTypeCat(string TypeCategoryName)
        {
            var myCategory = new TypeCategory();
            myCategory.TypeCategoryName = TypeCategoryName;


            using (ProductContext _db = new ProductContext())
            {
                // Add product to DB.
                _db.TypeCategories.Add(myCategory);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }


    }
}