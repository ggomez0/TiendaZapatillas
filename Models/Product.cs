using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaZapatillas.Models
{
    public class Product
    {
        [ScaffoldColumn(false), Key]
        public int ProductID { get; set; }

        [Required, StringLength(100), Display(Name = "Nombre")]
        public string ProductName { get; set; }

        [StringLength(10000), Display(Name = "Descripcion producto"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [Required, Display(Name = "Precio")]
        public double? UnitPrice { get; set; }

        public int? MarcaID { get; set; }
        public int? GenCategoryID { get; set; }
        public int? TypeCategoryID { get; set; }

        public int? stock { get; set; }
        public int? vendido { get; set; }

        //Categorias
        public virtual Marca Marca { get; set; }
        public virtual GeneroCategory GeneroCategory { get; set; }
        public virtual TypeCategory TypeCategory { get; set; }
        // ----

        public virtual depositos Depositos { get; set; }

        public bool Visible { get; set;}

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<prodendep> Prodendeps { get; set; }
        public virtual ICollection<Detalles_Movimientos> detalles_Movimientos { get; set; }


    }
}