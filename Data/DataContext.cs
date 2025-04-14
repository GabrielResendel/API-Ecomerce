using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
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
        public DbSet<ProdutoTamanho> ProdutoTamanhos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }
        }
    }