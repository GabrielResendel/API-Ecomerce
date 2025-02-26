using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaGR.DTOs;

namespace LojaGR.DTOs
{
    public class ProdutoDto
    {
        public int Id {get; set;}
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
    }
}