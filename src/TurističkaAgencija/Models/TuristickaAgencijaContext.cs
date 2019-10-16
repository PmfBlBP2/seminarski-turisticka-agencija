using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TurističkaAgencija.Models
{
    public partial class TuristickaAgencijaContext : DbContext
    {
        public TuristickaAgencijaContext()
        {
        }

        public TuristickaAgencijaContext(DbContextOptions<TuristickaAgencijaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Destinacija> Destinacija { get; set; }
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Kompanija> Kompanija { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Ponuda> Ponuda { get; set; }
        public virtual DbSet<Prevoz> Prevoz { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<Smjestaj> Smjestaj { get; set; }
        public virtual DbSet<TipPrevoza> TipPrevoza { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=turisticka_agencija");
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Destinacija>(entity =>
            {
                entity.ToTable("destinacija", "turisticka_agencija");

                entity.HasIndex(e => e.DrzavaId)
                    .HasName("fk_destinacija_drzava1_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("DestinacijaId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DrzavaId).HasColumnType("int(11)");

                entity.Property(e => e.Grad)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.Property(e => e.Slika)
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Destinacija)
                    .HasForeignKey(d => d.DrzavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_destinacija_drzava1");
            });

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.ToTable("drzava", "turisticka_agencija");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kompanija>(entity =>
            {
                entity.ToTable("kompanija", "turisticka_agencija");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Grad)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.ToTable("korisnik", "turisticka_agencija");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.BrojTelefona)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.DatumRodjenja).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ponuda>(entity =>
            {
                entity.ToTable("ponuda", "turisticka_agencija");

                entity.HasIndex(e => e.DestinacijaId)
                    .HasName("fk_ponuda_destinacija1_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("IdPutovanja_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PrevozId)
                    .HasName("fk_ponuda_prevoz1_idx");

                entity.HasIndex(e => e.SmjestajId)
                    .HasName("fk_ponuda_smjestaj1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.BrojMijesta).HasColumnType("int(11)");

                entity.Property(e => e.Cijena).HasColumnType("decimal(10,2)");

                entity.Property(e => e.DatumKreiranja).HasColumnType("date");

                entity.Property(e => e.DestinacijaId).HasColumnType("int(11)");

                entity.Property(e => e.Kraj).HasColumnType("date");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Pocetak).HasColumnType("date");

                entity.Property(e => e.PrevozId).HasColumnType("int(11)");

                entity.Property(e => e.SmjestajId).HasColumnType("int(11)");

                entity.HasOne(d => d.Destinacija)
                    .WithMany(p => p.Ponuda)
                    .HasForeignKey(d => d.DestinacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ponuda_destinacija1");

                entity.HasOne(d => d.Prevoz)
                    .WithMany(p => p.Ponuda)
                    .HasForeignKey(d => d.PrevozId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ponuda_prevoz1");

                entity.HasOne(d => d.Smjestaj)
                    .WithMany(p => p.Ponuda)
                    .HasForeignKey(d => d.SmjestajId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ponuda_smjestaj1");
            });

            modelBuilder.Entity<Prevoz>(entity =>
            {
                entity.ToTable("prevoz", "turisticka_agencija");

                entity.HasIndex(e => e.KompanijaId)
                    .HasName("fk_prevoz_kompanija1_idx");

                entity.HasIndex(e => e.TipPrevozaId)
                    .HasName("fk_prevoz_tip_prevoza1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.KompanijaId).HasColumnType("int(11)");

                entity.Property(e => e.Opis)
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.Property(e => e.TipPrevozaId).HasColumnType("int(11)");

                entity.HasOne(d => d.Kompanija)
                    .WithMany(p => p.Prevoz)
                    .HasForeignKey(d => d.KompanijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_prevoz_kompanija1");

                entity.HasOne(d => d.TipPrevoza)
                    .WithMany(p => p.Prevoz)
                    .HasForeignKey(d => d.TipPrevozaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_prevoz_tip_prevoza1");
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.ToTable("rezervacija", "turisticka_agencija");

                entity.HasIndex(e => e.KorisnikId)
                    .HasName("fk_rezervacija_korisnik1_idx");

                entity.HasIndex(e => e.PonudaId)
                    .HasName("fk_rezervacija_ponuda1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Iznos).HasColumnType("decimal(10,2)");

                entity.Property(e => e.KorisnikId).HasColumnType("int(11)");

                entity.Property(e => e.PonudaId).HasColumnType("int(11)");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rezervacija_korisnik1");

                entity.HasOne(d => d.Ponuda)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.PonudaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rezervacija_ponuda1");
            });

            modelBuilder.Entity<Smjestaj>(entity =>
            {
                entity.ToTable("smjestaj", "turisticka_agencija");

                entity.HasIndex(e => e.DestinacijaId)
                    .HasName("fk_smjestaj_destinacija1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.DestinacijaId).HasColumnType("int(11)");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.Property(e => e.Slika)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Destinacija)
                    .WithMany(p => p.Smjestaj)
                    .HasForeignKey(d => d.DestinacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_smjestaj_destinacija1");
            });

            modelBuilder.Entity<TipPrevoza>(entity =>
            {
                entity.ToTable("tip_prevoza", "turisticka_agencija");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(1024)
                    .IsUnicode(false);
            });
        }
    }
}
