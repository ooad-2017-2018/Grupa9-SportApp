namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OOADKorisnici")]
    public partial class OOADKorisnici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OOADKorisnici()
        {
            OOADClanoviTimas = new HashSet<OOADClanoviTima>();
            OOADPorukas = new HashSet<OOADPoruka>();
            OOADPorukas1 = new HashSet<OOADPoruka>();
            OOADProsliTimovis = new HashSet<OOADProsliTimovi>();
            OOADTimovis = new HashSet<OOADTimovi>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string Ime { get; set; }

        [Required]
        [StringLength(255)]
        public string Prezime { get; set; }

        [Column(TypeName = "date")]
        public DateTime Rodjen { get; set; }

        [Required]
        [StringLength(50)]
        public string drzava { get; set; }

        [Required]
        [StringLength(50)]
        public string grad { get; set; }

        public int dostupnost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADClanoviTima> OOADClanoviTimas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADPoruka> OOADPorukas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADPoruka> OOADPorukas1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADProsliTimovi> OOADProsliTimovis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OOADTimovi> OOADTimovis { get; set; }
    }
}
