using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Models;
using LojaGR.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
        [ApiController]
    [Route("api/[controller]")]
    public class ProdutoTamanhoController : ControllerBase
    {
         private readonly DataContext _context;

            public ProdutoTamanhoController(DataContext context)
            {
                _context = context;
            }

                    [HttpGet("{produtoId}")]
            public async Task<IActionResult> GetTamanhosPorProduto(int produtoId)
            {
                var tamanhos = await _context.ProdutoTamanhos
                    .Where(pt => pt.ProdutoId == produtoId)
                    .Select(pt => new { pt.Id, pt.P, pt.M, pt.G, pt.GG })
                    .ToListAsync();

                if (!tamanhos.Any()) return NotFound("Nenhum tamanho encontrado para este produto.");

                return Ok(tamanhos);
            }

              [HttpPost]
            public async Task<IActionResult> CreateProdutoTamanho([FromBody] ProdutoTamanhoDto dto)
            {
                var produto = await _context.Produtos.FindAsync(dto.ProdutoId);
                if (produto == null) return NotFound("Produto não encontrado");

                var novoProdutoTamanho = new ProdutoTamanho
                {
                    ProdutoId = dto.ProdutoId,
                    P = dto.P,
                    M = dto.M,
                    G = dto.G,
                    GG = dto.GG
                };

                _context.ProdutoTamanhos.Add(novoProdutoTamanho);
                await _context.SaveChangesAsync();
                return Ok(novoProdutoTamanho);
            }

              [HttpPut("{id}")]
            public async Task<IActionResult> UpdateProdutoTamanho(int id, [FromBody] ProdutoTamanhoDto dto)
            {
                var produtoTamanho = await _context.ProdutoTamanhos.FindAsync(id);
                if (produtoTamanho == null) return NotFound("Produto Tamanho não encontrado");

                produtoTamanho.P = dto.P;
                produtoTamanho.M = dto.M;
                produtoTamanho.G = dto.G;
                produtoTamanho.GG = dto.GG;
                await _context.SaveChangesAsync();
                return Ok(produtoTamanho);
            }

              [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProdutoTamanho(int id)
            {
                var produtoTamanho = await _context.ProdutoTamanhos.FindAsync(id);
                if (produtoTamanho == null) return NotFound("Produto Tamanho não encontrado");

                _context.ProdutoTamanhos.Remove(produtoTamanho);
                await _context.SaveChangesAsync();
                return Ok("Produto Tamanho removido com sucesso.");
            }



    }

    
}