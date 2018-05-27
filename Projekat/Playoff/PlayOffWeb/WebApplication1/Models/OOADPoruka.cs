namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OOADPoruka")]
    public partial class OOADPoruka
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Sadrzaj { get; set; }

        public int Posiljaoc { get; set; }

        public int Primaoc { get; set; }

        public int Vidjenost { get; set; }

        public virtual OOADKorisnici OOADKorisnici { get; set; }

        public virtual OOADKorisnici OOADKorisnici1 { get; set; }
    }
}
