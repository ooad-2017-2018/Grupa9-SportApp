namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OOADZahtjev")]
    public partial class OOADZahtjev
    {
        [StringLength(200)]
        public string Sadrzaj { get; set; }

        public int? Vidjenost { get; set; }

        public int? Primaoc { get; set; }

        public int? Posiljaoc { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
    }
}
