namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OOADTimovi")]
    public partial class OOADTimovi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OOADTimovi()
        {
            OOADMecs = new HashSet<OOADMec>();
            OOADMecs1 = new HashSet<OOADMec>();
            OOADReviews = new HashSet<OOADReview>();
            OOADSampionats = new HashSet<OOADSampionat>();
            OOADClanoviTimas = new HashSet<OOADClanoviTima>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        public int KorisnikID { get; set; }

        public int SportID { get; set; }

        public virtual OOADKorisnici OOADKorisnici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADMec> OOADMecs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADMec> OOADMecs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADReview> OOADReviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADSampionat> OOADSampionats { get; set; }

        public virtual OOADSport OOADSport { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADClanoviTima> OOADClanoviTimas { get; set; }
    }
}
