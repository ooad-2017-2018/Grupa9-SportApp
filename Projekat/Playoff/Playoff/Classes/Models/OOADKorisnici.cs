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


    }
}
