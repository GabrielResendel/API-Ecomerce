using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace LojaGR.Models
{
    public class Produto
    {
        public int Id {get; set;}
        public string Nome {get; set;} = string.Empty;

        [Column(TypeName = "decimal(18,4)")]
        public decimal Preco {get; set;}

        public string Descricao {get; set;} = string.Empty;

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;

        public List<ProdutoCor> ProdutoCores {get; set;} = new();
        public List<Imagem> Imagens {get; set;} = new();
    }
}