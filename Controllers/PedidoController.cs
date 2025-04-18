
using api.DTOs;
using api.Models;
using LojaGR.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly DataContext _context;

        public PedidoController(DataContext context)
        {
            _context = context;
        }

        // POST: api/pedidos
        [HttpPost("created")]
        public async Task<ActionResult> CriarPedido(PedidoDto dto)
        {
            var pedido = new Pedido
            {
                NomeCliente = dto.NomeCliente,
                Endereco = dto.Endereco,
                WhatsApp = dto.WhatsApp,
                FormaPagamento = dto.FormaPagamento,
                ValorTotal = dto.ValorTotal,
                Status = "Novo Pedido",
                Itens = dto.Itens.Select(i => new ItemPedido
                {
                    ProdutoId = i.ProdutoId,
                    NomeProduto = i.NomeProduto,
                    Cor = i.Cor,
                    Tamanho = i.Tamanho,
                    Quantidade = i.Quantidade,
                    PrecoUnitario = i.PrecoUnitario
                }).ToList()
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            foreach (var item in pedido.Itens)
            {
                var produtoTamanho = await _context.ProdutoTamanhos
                    .FirstOrDefaultAsync(p => p.ProdutoId == item.ProdutoId);

                if (produtoTamanho != null)
                {
                    switch (item.Tamanho.ToUpper())
                    {
                        case "P":
                            produtoTamanho.P -= item.Quantidade;
                            break;
                        case "M":
                            produtoTamanho.M -= item.Quantidade;
                            break;
                        case "G":
                            produtoTamanho.G -= item.Quantidade;
                            break;
                        case "GG":
                            produtoTamanho.GG -= item.Quantidade;
                            break;
                    }
                }
            }

            await _context.SaveChangesAsync();

            return Ok(new { pedido.Id });
        }

        // GET: api/pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> ObterTodosPedidos()
        {
            return await _context.Pedidos.Include(p => p.Itens).ToListAsync();      
        }

        // GET: api/pedidos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> ObterPedidoPorId(int id)
        {
            var pedido = await _context.Pedidos.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id == id);
                
                if (pedido == null)return NotFound();
                
                return Ok(pedido); // Retorna 200 OK com o pedido encontrado
                 
        }

        [HttpPost("verificar-estoque")]
        public async Task<IActionResult> VerificarEstoque([FromBody] List<ItemVerificacaoEstoqueDto> itens)
        {
            List<string> indisponiveis = new();

            foreach (var item in itens)
            {
                var produtoTamanho = await _context.ProdutoTamanhos
                    .FirstOrDefaultAsync(p => p.ProdutoId == item.ProdutoId);

                if (produtoTamanho == null)
                {
                    indisponiveis.Add($"{item.NomeProduto} - Estoque não cadastrado.");
                    continue;
                }

                bool disponivel = item.Tamanho.ToUpper() switch
                {
                    "P" => produtoTamanho.P >= item.Quantidade,
                    "M" => produtoTamanho.M >= item.Quantidade,
                    "G" => produtoTamanho.G >= item.Quantidade,
                    "GG" => produtoTamanho.GG >= item.Quantidade,
                    _ => false
                };

                if (!disponivel)
                {
                    indisponiveis.Add($"{item.NomeProduto} - Tam: {item.Tamanho} indisponível");
                }
            }

            if (indisponiveis.Any())
            {
                return BadRequest(new { mensagem = "Itens indisponíveis", itens = indisponiveis });
            }

            return Ok(new { mensagem = "Todos os itens estão disponíveis." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPedido(int id, PedidoDto dto)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Itens)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null) return NotFound();

            // Atualiza os dados principais do pedido
            pedido.NomeCliente = dto.NomeCliente;
            pedido.Endereco = dto.Endereco;
            pedido.WhatsApp = dto.WhatsApp;
            pedido.FormaPagamento = dto.FormaPagamento;
            pedido.ValorTotal = dto.ValorTotal;
            pedido.Status = dto.Status;

            // Atualização inteligente de itens
            var novosIds = dto.Itens.Select(i => i.Id).ToList();

            // Remove itens que não estão mais no DTO
            pedido.Itens.RemoveAll(i => !novosIds.Contains(i.Id));

            foreach (var itemDto in dto.Itens)
            {
                var itemExistente = pedido.Itens.FirstOrDefault(i => i.Id == itemDto.Id);

                if (itemExistente != null)
                {
                    // Atualiza item existente
                    itemExistente.NomeProduto = itemDto.NomeProduto;
                    itemExistente.Cor = itemDto.Cor;
                    itemExistente.Tamanho = itemDto.Tamanho;
                    itemExistente.Quantidade = itemDto.Quantidade;
                    itemExistente.PrecoUnitario = itemDto.PrecoUnitario;
                }
                else
                {
                    // Adiciona novo item
                    pedido.Itens.Add(new ItemPedido
                    {
                        ProdutoId = itemDto.ProdutoId,
                        NomeProduto = itemDto.NomeProduto,
                        Cor = itemDto.Cor,
                        Tamanho = itemDto.Tamanho,
                        Quantidade = itemDto.Quantidade,
                        PrecoUnitario = itemDto.PrecoUnitario
                    });
                }
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }


        
        // DELETE: api/pedidos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPedido(int id)
        {
                    
            var pedido = await _context.Pedidos.FindAsync(id);
        
                 if (pedido == null)return NotFound();
                   _context.Pedidos.Remove(pedido);
                    await _context.SaveChangesAsync();
        
                    return NoContent();     
        
                    
        }

    }
}