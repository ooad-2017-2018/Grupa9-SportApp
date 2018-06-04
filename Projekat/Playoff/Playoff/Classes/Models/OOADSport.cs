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

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(25)]
        public string Naziv { get; set; }

        public int MaxBrojIgraca { get; set; }

        public int MinBrojIgraca { get; set; }


    }
}
