using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaGR.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaGR.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<ProdutoCor> ProdutoCores { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoCor>()
                .HasKey(pc => new { pc.ProdutoId, pc.CorId });
                

            modelBuilder.Entity<ProdutoCor>()
                .HasOne(pc => pc.Produto)
                .WithMany(p => p.ProdutoCores)
                .HasForeignKey(pc => pc.ProdutoId);

            modelBuilder.Entity<ProdutoCor>()
                .HasOne(pc => pc.Cor)
                .WithMany(c => c.ProdutoCores)
                .HasForeignKey(pc => pc.CorId);
        }

        private object Property(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}