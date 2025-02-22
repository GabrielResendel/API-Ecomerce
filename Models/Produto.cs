using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LojaGR.Data;
using Microsoft.EntityFrameworkCore;
namespace LojaGR.Models
{
    public class Produto
    {
        [Key]
        public int Id {get; set;}
        public string Nome {get; set;} = string.Empty;

        [Column(TypeName = "decimal(18,4)")]
        public decimal Preco {get; set;}

        public string Descricao {get; set;} = string.Empty;

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        
        public Categoria Categoria { get; set; } = null!;

         public List<Imagem> Imagens {get; set;} = new();
    }
}