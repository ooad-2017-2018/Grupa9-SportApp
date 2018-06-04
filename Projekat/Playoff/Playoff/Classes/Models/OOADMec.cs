namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OOADMec")]
    public partial class OOADMec
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime VrijemeOdrzavanja { get; set; }

        [Required]
        [StringLength(25)]
        public string MjestoOdrzavanja { get; set; }

        public int TIM1 { get; set; }

        public int TIM2 { get; set; }


    }
}
