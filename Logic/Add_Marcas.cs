using TiendaZapatillas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaZapatillas.Logic
{
    public class AddMarca
    {
        public bool AddMarcas(string MarcasName, string Description, string paisorigen, string Imagen_marca, string paginaweb_marca)
        {
            var myCategory = new Marca();
            myCategory.MarcaName = MarcasName;
            myCategory.Description = Description;
            myCategory.paisorigen = paisorigen;
            myCategory.Imagen_marca = Imagen_marca;
            myCategory.paginaweb_marca = paginaweb_marca;

            using (ProductContext _db = new ProductContext())
            {
                // Add product to DB.
                _db.Marcas.Add(myCategory);
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