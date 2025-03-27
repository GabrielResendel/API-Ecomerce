using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaGR.Data;
using LojaGR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

    namespace LojaGR.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
        {
            private readonly DataContext _context;

            public CategoriaController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
            {
                return await _context.Categorias.ToListAsync();
            }
            [HttpGet("{id}")]
            public async Task<ActionResult<Categoria>> GetCategoria(int id)
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria == null)
                {
                    return NotFound("Categoria não encontrada.");
                }
                return Ok(categoria);
            }

            [HttpPost]
            public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCategorias), new { id = categoria.Id }, categoria);
            }
        }

    }
        