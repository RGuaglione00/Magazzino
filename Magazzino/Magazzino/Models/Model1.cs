using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Magazzino.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CategoriaProdotti> CategoriaProdotti { get; set; }
        public virtual DbSet<Prodotti> Prodotti { get; set; }
        public virtual DbSet<Produttori> Produttori { get; set; }
        public virtual DbSet<vProdotti> vProdotti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaProdotti>()
                .HasMany(e => e.Prodotti)
                .WithOptional(e => e.CategoriaProdotti)
                .HasForeignKey(e => e.IdCategoriaProdotti);

            modelBuilder.Entity<Prodotti>()
                .Property(e => e.Prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Produttori>()
                .HasMany(e => e.Prodotti)
                .WithOptional(e => e.Produttori)
                .HasForeignKey(e => e.IdProduttori);

            modelBuilder.Entity<vProdotti>()
                .Property(e => e.Prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vProdotti>()
                .Property(e => e.Attivo)
                .IsUnicode(false);

            modelBuilder.Entity<vProdotti>()
                .Property(e => e.DataProduzione)
                .IsUnicode(false);
        }
    }
}
