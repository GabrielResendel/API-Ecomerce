using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaGR.DTOs
{
    public class ImagemDto
    {
        public int Id {get; set;}
        public string Url { get; set; } = string.Empty;
        public int ProdutoId { get; set; }
        public int CorId { get; set; }
    }
}