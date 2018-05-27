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

            modelBuilder.Entity<OOADKorisnici>()
                .HasMany(e => e.OOADClanoviTimas)
                .WithRequired(e => e.OOADKorisnici)
                .HasForeignKey(e => e.Tim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OOADKorisnici>()
                .HasMany(e => e.OOADPorukas)
                .WithRequired(e => e.OOADKorisnici)
                .HasForeignKey(e => e.Posiljaoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OOADKorisnici>()
                .HasMany(e => e.OOADPorukas1)
                .WithRequired(e => e.OOADKorisnici1)
                .HasForeignKey(e => e.Primaoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OOADKorisnici>()
                .HasMany(e => e.OOADProsliTimovis)
                .WithRequired(e => e.OOADKorisnici)
                .HasForeignKey(e => e.Korisnik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OOADKorisnici>()
                .HasMany(e => e.OOADTimovis)
                .WithRequired(e => e.OOADKorisnici)
                .HasForeignKey(e => e.KorisnikID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OOADMec>()
                .Property(e => e.MjestoOdrzavanja)
                .IsUnicode(false);

            modelBuilder.Entity<OOADMec>()
                .HasMany(e => e.OOADRezultats)
                .WithRequired(e => e.OOADMec)
                .HasForeignKey(e => e.MecID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OOADNaziviPozicija>()
                .Property(e => e.Naziv)
                .IsUnicode(false);

            modelBuilder.Entity<OOADNaziviPozicija>()
                .HasMany(e => e.OOADSports)
                .WithMany(e => e.OOADNaziviPozicijas)
                .Map(m => m.ToTable("OOADPozicije").MapLeftKey("PozID").MapRightKey("SportID"));

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

            modelBuilder.Entity<OOADSport>()
                .HasMany(e => e.OOADTimovis)
                .WithRequired(e => e.OOADSport)
                .HasForeignKey(e => e.SportID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OOADTimovi>()
                .Property(e => e.Ime)
                .IsUnicode(false);

            modelBuilder.Entity<OOADTimovi>()
                .HasMany(e => e.OOADMecs)
                .WithRequired(e => e.OOADTimovi)
                .HasForeignKey(e => e.TIM1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OOADTimovi>()
                .HasMany(e => e.OOADMecs1)
                .WithRequired(e => e.OOADTimovi1)
                .HasForeignKey(e => e.TIM2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OOADTimovi>()
                .HasMany(e => e.OOADReviews)
                .WithOptional(e => e.OOADTimovi)
                .HasForeignKey(e => e.TIM);

            modelBuilder.Entity<OOADTimovi>()
                .HasMany(e => e.OOADSampionats)
                .WithRequired(e => e.OOADTimovi)
                .HasForeignKey(e => e.TimoviID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OOADTimovi>()
                .HasMany(e => e.OOADClanoviTimas)
                .WithRequired(e => e.OOADTimovi)
                .HasForeignKey(e => e.Tim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OOADProsliTimovi>()
                .Property(e => e.Naziv)
                .IsUnicode(false);
        }
    }
}
