namespace paginaMuestraMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Casas
    {
        [Key]
        public int idCasa { get; set; }

        [Required]
        [StringLength(15)]
        public string tipodeCasa { get; set; }

        [Required]
        [StringLength(50)]
        public string Ubicacion { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public int? Dueño { get; set; }

        public virtual Dueños Dueños { get; set; }
    }
}
