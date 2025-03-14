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
        public int Quantidade {get; set;}

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        
        public Categoria? Categoria { get; set; }
        public string Capa {get;set;} = string.Empty;

         public List<Imagem> Imagens {get; set;} = new();

    }
}