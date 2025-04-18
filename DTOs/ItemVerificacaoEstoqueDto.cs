using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class ItemVerificacaoEstoqueDto
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public string Tamanho { get; set; } = string.Empty; 
        public int Quantidade { get; set; }
    }
}