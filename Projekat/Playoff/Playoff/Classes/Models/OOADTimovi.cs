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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        public int KorisnikID { get; set; }

        public int SportID { get; set; }

        public int? MMR { get; set; }
    }
}
