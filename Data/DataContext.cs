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
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProdutoCor> ProdutoCors {get; set;}

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<ProdutoCor>()
        //         .HasKey(pc => new { pc.ProdutoId, pc.CorId });
                

        //     modelBuilder.Entity<ProdutoCor>()
        //         .HasOne(pc => pc.Produto)
        //         .WithMany(p => p.ProdutoCores)
        //         .HasForeignKey(pc => pc.ProdutoId);

        //     modelBuilder.Entity<ProdutoCor>()
        //         .HasOne(pc => pc.Cor)
        //         .WithMany(c => c.ProdutoCores)
        //         .HasForeignKey(pc => pc.CorId);

        //          // Definir a relação entre Produto e Categoria
        //     modelBuilder.Entity<Produto>()
        //         .HasOne(p => p.Categoria)
        //         .WithMany(c => c.Produtos)  // Uma Categoria pode ter vários Produtos
        //         .HasForeignKey(p => p.CategoriaId)
        //         .OnDelete(DeleteBehavior.Restrict); // Evita exclusão em cascata
        // }

    //     private object Property(Func<object, object> value)
    //     {
    //         throw new NotImplementedException();
    //     }
     }
    }