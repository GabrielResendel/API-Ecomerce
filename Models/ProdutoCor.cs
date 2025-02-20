using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaGR.Models
{
    public class ProdutoCor
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;
        
        public int CorId { get; set; }
        public Cor Cor { get; set; } = null!;
    }
}