namespace paginaMuestraMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dueños
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dueños()
        {
            Casas = new HashSet<Casas>();
        }

        [Key]
        public int idDueño { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public int Edad { get; set; }

        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Casas> Casas { get; set; }
    }
}
