using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LojaGR.Models
{
    public class Imagem
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        [JsonIgnore]
        public Produto Produto { get; set; } = null!;

        [ForeignKey("Cor")]
        public int CorId { get; set; }
        public Cor Cor { get; set; } = null!;
    }
}