namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OOADReview")]
    public partial class OOADReview
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(255)]
        public string komentar { get; set; }

        public int ocjena { get; set; }

        public int? TIM { get; set; }

        public virtual OOADTimovi OOADTimovi { get; set; }
    }
}
