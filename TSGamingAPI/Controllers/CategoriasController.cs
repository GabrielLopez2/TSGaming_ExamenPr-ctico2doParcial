using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSGamingAPI.Data;
using TSGamingAPI.Models;

namespace TSGamingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly TSGamingContext _context;

        public CategoriasController(TSGamingContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
