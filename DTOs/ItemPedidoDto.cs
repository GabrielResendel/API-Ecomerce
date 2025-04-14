using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class ItemPedidoDto
    {
        public string ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string Cor {get; set;}
        public string Tamanho {get; set;}
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        
    }
}