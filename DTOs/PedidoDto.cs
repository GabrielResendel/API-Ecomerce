using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;

namespace api.DTOs
{
    public class PedidoDto
    {
        public string NomeCliente { get; set; }
        public string WhatsApp { get; set; }
        public string Endereco { get; set; }
        public string FormaPagamento { get; set; }
        public decimal ValorTotal { get; set; }
        public LinkedList<ItemPedidoDto> Itens { get; set; }
    }
}