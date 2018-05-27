namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OOADSport")]
    public partial class OOADSport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OOADSport()
        {
            OOADTimovis = new HashSet<OOADTimovi>();
            OOADNaziviPozicijas = new HashSet<OOADNaziviPozicija>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(25)]
        public string Naziv { get; set; }

        public int MaxBrojIgraca { get; set; }

        public int MinBrojIgraca { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADTimovi> OOADTimovis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADNaziviPozicija> OOADNaziviPozicijas { get; set; }
    }
}
