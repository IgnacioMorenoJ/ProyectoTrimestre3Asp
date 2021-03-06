//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTrimestre3Asp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proveedor()
        {
            this.productoes = new HashSet<producto>();
        }
    
        public int id { get; set; }

        [Required(ErrorMessage = "Diligencie el campo Nombre")]
        [StringLength(25, ErrorMessage = "El limite de caracteres es de 25")]
        public string nombre { get; set; }


        [Required(ErrorMessage = "Diligencie el campo Direccion")]
        [StringLength(60, ErrorMessage = "El limite de caracteres es de 60")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "Diligencie el campo Telefono")]
        [StringLength(25, ErrorMessage = "El limite de caracteres es de 25")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "Diligencie el campo Nombre Contacto")]
        public string nombre_contacto { get; set; }


    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<producto> productoes { get; set; }
    }
}
