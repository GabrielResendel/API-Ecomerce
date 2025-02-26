using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaGR.Data;
using LojaGR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaGR.DTOs;

namespace LojaGR.Controllers
{
        [ApiController]
    [Route("api/[controller]")]
    public class ImagemController : ControllerBase
    {
        private readonly DataContext _context;

        public ImagemController(DataContext context)
        {
            _context = context;
        }

        // Buscar todas as imagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imagem>>> GetImagens()
        {
            return await _context.Imagens.Include(i => i.Produto).Include(i => i.Cor).ToListAsync();
        }

        // Buscar imagens por ProdutoId e CorId
        [HttpGet("{produtoId}/{corId}")]
        public async Task<ActionResult<IEnumerable<Imagem>>> GetImagensPorProdutoECor(int produtoId, int corId)
        {
            var imagens = await _context.Imagens
                .Where(img => img.ProdutoId == produtoId && img.CorId == corId)
                .ToListAsync();

            if (!imagens.Any())
            {
                return NotFound("Nenhuma imagem encontrada para esse produto e cor.");
            }

            return imagens;
        }

        // Criar nova imagem
        [HttpPost("created")]
        public async Task<ActionResult<Imagem>> PostImagem([FromBody] ImagemDto imagemDto)
        {
                    var imagem = new Imagem
            {
                Url = imagemDto.Url,
                ProdutoId = imagemDto.ProdutoId,
                CorId = imagemDto.CorId
            };

            _context.Imagens.Add(imagem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostImagem), new { id = imagem.Id }, imagem);
        }

        // Atualizar imagem
       [HttpPut("{id}")]
    public async Task<IActionResult> PutImagem(int id, [FromBody] ImagemDto imagemDto)
    {
        if (id != imagemDto.Id)
            return BadRequest("O ID da imagem não corresponde ao ID fornecido na URL.");

        var imagem = await _context.Imagens.FindAsync(id);
        if (imagem == null)
            return NotFound("Imagem não encontrada.");

        // Atualiza os campos da imagem
        imagem.Url = imagemDto.Url;
        imagem.ProdutoId = imagemDto.ProdutoId;
        imagem.CorId = imagemDto.CorId;

        _context.Entry(imagem).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }


        // Deletar imagem
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagem(int id)
        {
            var imagem = await _context.Imagens.FindAsync(id);
            if (imagem == null) return NotFound();

            _context.Imagens.Remove(imagem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}