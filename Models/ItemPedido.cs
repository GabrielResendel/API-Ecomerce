using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace api.Models
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }
        [JsonIgnore]
        public Pedido Pedido { get; set; }

        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string Cor { get; set; }
        public string Tamanho { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }
    }
}