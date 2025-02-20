using System;
using LojaGR.Models;
using Microsoft.AspNetCore.Mvc;
namespace LojaGR.Controllers
{
  
        [ApiController]
        [Route("api/[controller]")]
        public class ProdutoController : ControllerBase
        {
            [HttpGet]
            public IActionResult Get()
            {
                return Ok(new { message = "API funcionando!" });
            }
        }
    
}