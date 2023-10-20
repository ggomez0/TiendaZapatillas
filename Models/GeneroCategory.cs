using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaZapatillas.Models
{
    public class GeneroCategory
    {
        [ScaffoldColumn(false), Key ]
        public int GenCategoryID { get; set; }

        [Required, StringLength(100), Display(Name = "Nombre")]
        public string GeneroName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}