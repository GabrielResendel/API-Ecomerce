using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaGR.Models
{
    public class ProdutoCor
    {
        [Key]
        public int Id {get; set;}
        
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;

        [ForeignKey("Cor")]
        public int CorId { get; set; }
        public Cor Cor { get; set; } = null!;
    }
}