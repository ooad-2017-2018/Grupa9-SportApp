namespace WebApplication1.Models {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PlayoffM : DbContext {
        public PlayoffM()
            : base("name=PlayoffM") {
        }

        public virtual DbSet<OOADKorisnici> OOADKorisnicis { get; set; }
        public virtual DbSet<OOADMec> OOADMecs { get; set; }
        public virtual DbSet<OOADNaziviPozicija> OOADNaziviPozicijas { get; set; }
        public virtual DbSet<OOADPoruka> OOADPorukas { get; set; }
        public virtual DbSet<OOADReview> OOADReviews { get; set; }
        public virtual DbSet<OOADSampionat> OOADSampionats { get; set; }
        public virtual DbSet<OOADSport> OOADSports { get; set; }
        public virtual DbSet<OOADTimovi> OOADTimovis { get; set; }
        public virtual DbSet<OOADClanoviTima> OOADClanoviTimas { get; set; }
        public virtual DbSet<OOADProsliTimovi> OOADProsliTimovis { get; set; }
        public virtual DbSet<OOADRezultat> OOADRezultats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<OOADKorisnici>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<OOADKorisnici>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<OOADKorisnici>()
                .Property(e => e.Ime)
                .IsUnicode(false);

            modelBuilder.Entity<OOADKorisnici>()
                .Property(e => e.Prezime)
                .IsUnicode(false);

            modelBuilder.Entity<OOADKorisnici>()
                .Property(e => e.drzava)
                .IsUnicode(false);

            modelBuilder.Entity<OOADKorisnici>()
                .Property(e => e.grad)
                .IsUnicode(false);

           

            modelBuilder.Entity<OOADMec>()
                .Property(e => e.MjestoOdrzavanja)
                .IsUnicode(false);

           

            modelBuilder.Entity<OOADPoruka>()
                .Property(e => e.Sadrzaj)
                .IsUnicode(false);

            modelBuilder.Entity<OOADReview>()
                .Property(e => e.komentar)
                .IsUnicode(false);

            modelBuilder.Entity<OOADSampionat>()
                .Property(e => e.Naziv)
                .IsUnicode(false);

            modelBuilder.Entity<OOADSport>()
                .Property(e => e.Naziv)
                .IsUnicode(false);

    

            modelBuilder.Entity<OOADTimovi>()
                .Property(e => e.Ime)
                .IsUnicode(false);

           

            modelBuilder.Entity<OOADProsliTimovi>()
                .Property(e => e.Naziv)
                .IsUnicode(false);
        }
    }
}
