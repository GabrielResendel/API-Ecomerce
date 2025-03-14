using System;
using LojaGR.Data;
using LojaGR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaGR.DTOs;

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

        
          [HttpPost("created")]
          public async Task<ActionResult<Produto>> PostProduto([FromBody] ProdutoDto produtoDto)
          {
          var produto = new Produto
          {
               Nome = produtoDto.Nome,
               Preco = produtoDto.Preco,
               Descricao = produtoDto.Descricao,
               Quantidade = produtoDto.Quantidade,
               CategoriaId = produtoDto.CategoriaId,
               Capa = produtoDto.Capa
          };

          _context.Produtos.Add(produto);
          await _context.SaveChangesAsync();

          return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
          }


          [HttpPut("{id}")]
          public async Task<IActionResult> PutProduto(int id, [FromBody] ProdutoDto produtoDto)
          {
          var produto = await _context.Produtos.FindAsync(id);
          if (produto == null) return NotFound();

          produto.Nome = produtoDto.Nome;
          produto.Preco = produtoDto.Preco;
          produto.Descricao = produtoDto.Descricao;
          produto.Quantidade = produtoDto.Quantidade;
          produto.CategoriaId = produtoDto.CategoriaId;
          produto.Capa = produtoDto.Capa;

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