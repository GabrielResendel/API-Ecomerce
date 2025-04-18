using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class AtualizarPedidoDto
    {
        public string NomeCliente { get; set; }
        public string Endereco { get; set; }
        public string NumeroWhatsapp { get; set; }
        public string FormaPagamento { get; set; }
        public string Status { get; set; }

        public List<ItemPedidoDto> Itens { get; set; }
    }
}