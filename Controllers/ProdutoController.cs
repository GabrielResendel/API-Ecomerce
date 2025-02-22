using System;
using LojaGR.Data;
using LojaGR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaGR.Controllers
{
  
        [ApiController]
        [Route("api/[controller]")]
        public class ProdutoController : ControllerBase
        {
           private readonly DataContext _context;

           public ProdutoController(DataContext context)
           {
            _context = context;
           } 

           [HttpGet]
           public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
           {
                return await _context.Produtos.Include(p => p.Imagens).ToListAsync();
           }

           [HttpGet("{id}")]
           public async Task<ActionResult<Produto>> GetProduto(int id)
           {
                var produto = await _context.Produtos.Include(p => p.Imagens).FirstOrDefaultAsync(p => p.Id == id);
                if (produto == null) return NotFound();
                    return produto;
           }

           [HttpPost]
          public async Task<ActionResult<Produto>> PostProduto([FromBody] Produto produto)
           {
                Console.WriteLine($"Recebido: Nome={produto.Nome}, Preço={produto.Preco}, CategoriaId={produto.CategoriaId}");
               // Busca a categoria no banco de dados
               var categoria = await _context.Categorias.FindAsync(produto.CategoriaId);
               
               if (categoria == null)
                    return BadRequest(new { message = "Categoria não encontrada" });

               produto.Categoria = categoria; // Associa a categoria existente

               _context.Produtos.Add(produto);
               await _context.SaveChangesAsync();

               return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
           }

           [HttpPut("{id}")]
          public async Task<IActionResult> PutProduto(int id, Produto produto)
          {
               if (id != produto.Id) return BadRequest();

               var produtoExistente = await _context.Produtos.Include(p => p.Imagens).FirstOrDefaultAsync(p => p.Id == id);

               if (produtoExistente == null) return NotFound();

               // Atualiza os campos manualmente
               produtoExistente.Nome = produto.Nome;
               produtoExistente.Preco = produto.Preco;
               produtoExistente.Descricao = produto.Descricao;
               
               // Verifica se a categoria mudou
               if (produtoExistente.CategoriaId != produto.CategoriaId)
               {
                    var categoria = await _context.Categorias.FindAsync(produto.CategoriaId);
                    if (categoria == null) return BadRequest(new { message = "Categoria não encontrada" });

                    produtoExistente.CategoriaId = produto.CategoriaId;
                    produtoExistente.Categoria = categoria;
               }

               await _context.SaveChangesAsync();
               return NoContent();    
          }

           [HttpDelete("{id}")]
           public async Task<IActionResult> DeleteProduto(int id)
           {
                var produto = await _context.Produtos.FindAsync(id);
                if (produto == null) return NotFound();

                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return NoContent();
           }
        }
    
}