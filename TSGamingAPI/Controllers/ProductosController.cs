using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSGamingAPI.Data;
using TSGamingAPI.Models;

namespace TSGamingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly TSGamingContext _context;

        public ProductosController(TSGamingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetProductos()
        {
            var productos = await _context.Productos
                .Include(p => p.Categoria)
                .Select(p => new {
                    p.IdProducto,
                    p.Nombre,
                    p.Descripcion,
                    p.Precio,
                    p.ImagenUrl,
                    IdCategoria = p.IdCategoria, 
                    Categoria = new
                    {
                        p.Categoria.IdCategoria,
                        p.Categoria.Nombre
                    }
                })
                .ToListAsync();

            return productos;
        }

        [HttpGet("porNombre")]
        public async Task<ActionResult<IEnumerable<object>>> GetPorNombre(string nombre)
        {
            var productos = await _context.Productos
                .Where(p => p.Nombre.Contains(nombre))
                .Include(p => p.Categoria)
                .Select(p => new {
                    p.IdProducto,
                    p.Nombre,
                    p.Descripcion,
                    p.Precio,
                    p.ImagenUrl,
                    IdCategoria = p.IdCategoria,  
                    Categoria = new
                    {
                        p.Categoria.IdCategoria,
                        p.Categoria.Nombre
                    }
                })
                .ToListAsync();

            return productos;
        }

        [HttpGet("porCategoria/{idCategoria}")]
        public async Task<ActionResult<IEnumerable<object>>> GetPorCategoria(int idCategoria)
        {
            var productos = await _context.Productos
                .Where(p => p.IdCategoria == idCategoria)
                .Include(p => p.Categoria)
                .Select(p => new {
                    p.IdProducto,
                    p.Nombre,
                    p.Descripcion,
                    p.Precio,
                    p.ImagenUrl,
                    IdCategoria = p.IdCategoria,  
                    Categoria = new
                    {
                        p.Categoria.IdCategoria,
                        p.Categoria.Nombre
                    }
                })
                .ToListAsync();

            return productos;
        }
    }
}
