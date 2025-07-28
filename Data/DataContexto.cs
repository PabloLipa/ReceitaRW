using Localiza_Aplicattion.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Localiza_Aplicattion.Data
{
    public class DataContexto : DbContext
    {
       
        public DataContexto(DbContextOptions<DataContexto> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Empresas)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            
            modelBuilder.Entity<Empresa>()
                .HasIndex(e => new { e.Cnpj, e.UsuarioId })
                .IsUnique();
        }
        
    }
}
