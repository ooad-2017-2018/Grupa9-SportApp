namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OOADProsliTimovi")]
    public partial class OOADProsliTimovi
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Korisnik { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Naziv { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime datumprestanka { get; set; }

    }
}
