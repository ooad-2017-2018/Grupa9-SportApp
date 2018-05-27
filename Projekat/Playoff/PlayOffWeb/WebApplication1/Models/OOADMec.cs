namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OOADMec")]
    public partial class OOADMec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OOADMec()
        {
            OOADRezultats = new HashSet<OOADRezultat>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime VrijemeOdrzavanja { get; set; }

        [Required]
        [StringLength(25)]
        public string MjestoOdrzavanja { get; set; }

        public int TIM1 { get; set; }

        public int TIM2 { get; set; }

        public virtual OOADTimovi OOADTimovi { get; set; }

        public virtual OOADTimovi OOADTimovi1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADRezultat> OOADRezultats { get; set; }
    }
}
