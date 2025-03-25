using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LojaGR.Models;

namespace api.Models
{
    public class ProdutoTamanho
    {
        [Key]
        public int Id  {get;set;}

        [ForeignKey("Produto")]
        public int ProdutoId {get;set;}

        public Produto? Produto {get;set;}

        public int P {get;set;}
        public int M {get;set;}
        public int G {get;set;}
        public int GG {get;set;}

    }
}