using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaZapatillas.Models;

namespace TiendaZapatillas.Logic
{
    public class AddProducts
    {
        public bool AddProduct(string ProductName, string ProductDesc, string ProductPrice, string ProductCategory, string ProductImagePath, string GeneroCategory, string TypeCategory)
        {
            var myProduct = new Product();
            myProduct.ProductName = ProductName;
            myProduct.Description = ProductDesc;
            myProduct.UnitPrice = Convert.ToDouble(ProductPrice);
            myProduct.ImagePath = ProductImagePath;
            myProduct.CategoryID = Convert.ToInt32(ProductCategory);
            //myProduct.stock = Convert.ToInt32(stock);
            //myProduct.vendido = Convert.ToInt32(vendido);
            myProduct.GenCategoryID = Convert.ToInt32(GeneroCategory);
            myProduct.TypeCategoryID = Convert.ToInt32(TypeCategory);



            using (ProductContext _db = new ProductContext())
            {
                // Add product to DB.
                _db.Products.Add(myProduct);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
    }
}