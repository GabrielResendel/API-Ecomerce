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
    public class CorController : ControllerBase
    {
        private readonly DataContext _context;

        public CorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cor>>> GetCores()
        {
            return await _context.Cores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Cor>> PostCor(Cor cor)
        {
            _context.Cores.Add(cor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCores), new { id = cor.Id }, cor);
        }
    }
}