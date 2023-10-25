using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaZapatillas.Models
{
    public class Marca
    {
        [ScaffoldColumn(false), Key]
        public int MarcaID { get; set; }

        [Required, StringLength(100), Display(Name = "Nombre")]
        public string MarcaName { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        public string paisorigen { get; set; }
        public string Imagen_marca { get; set; }
        
        [Url]
        public string paginaweb_marca { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}