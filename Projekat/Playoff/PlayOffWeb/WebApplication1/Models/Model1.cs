namespace WebApplication1.Models {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext {
        public Model1()
            : base("name=Model11") {
        }

        public virtual DbSet<OOADTimovi> OOADTimovis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<OOADTimovi>()
                .Property(e => e.Ime)
                .IsUnicode(false);
        }
    }
}
