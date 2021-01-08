using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;
using Newtonsoft.Json;
namespace DataAccess
{
    public class DBContext : DbContext
    {
        public DBContext() { }
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-V83FI1O\\LENOVO;Database=Deneme;Trusted_Connection=True;", 
                b => b.MigrationsAssembly("API"));
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sube>()
                .HasMany<BilgisayarBaglanti>()
                .WithOne();
            
            modelBuilder.Entity<Sube>()
                .HasMany<Yetkili>()
                .WithOne();
            
            modelBuilder.Entity<Firma>()
                .HasMany<Sube>()
                .WithOne();
            
            modelBuilder.Entity<BilgisayarBaglanti>()
                .HasMany<Program>()
                .WithOne();

        }


        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Yetkili> Yetkililer { get; set; }
        public DbSet<Sube> Subeler { get; set; }
        public DbSet<Program> Programlar { get; set; }
        public DbSet<BilgisayarBaglanti> BilgisayarBaglantilari { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<VergiDairesi> VergiDaireleri { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

    }

    
    
}
