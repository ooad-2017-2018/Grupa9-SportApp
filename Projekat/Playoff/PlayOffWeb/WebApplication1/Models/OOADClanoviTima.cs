namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OOADClanoviTima")]
    public partial class OOADClanoviTima
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Korisnik { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tim { get; set; }

        public virtual OOADKorisnici OOADKorisnici { get; set; }

        public virtual OOADTimovi OOADTimovi { get; set; }
    }
}
