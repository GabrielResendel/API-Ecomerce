using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaGR.Models
{
    public class Cor
    {
        [Key]
        public int Id {get; set;}
        public string Nome {get; set;} = string.Empty;
        public string HexaDec {get; set;} = string.Empty;

    }
}