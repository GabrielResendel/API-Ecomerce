using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string WhatsApp { get; set; }
        public string Endereco { get; set; }
        public string FormaPagamento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }
        public string Status { get; set; } 

        public List<ItemPedido> Itens { get; set; }
    }
}