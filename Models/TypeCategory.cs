﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopGaspar.Models
{
    public class TypeCategory
    {
        [ScaffoldColumn(false)]
        public int TypeCategoryID { get; set; }

        [Required, StringLength(100), Display(Name = "Nombre")]
        public string TypeCategoryName { get; set; }

        [Display(Name = "Descripcion Producto")]
        public string TypeDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}