using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorAppResto2.Shared.Models;
namespace BlazorAppResto2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaProductoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CategoriaProductoController(DataContext context)
        {
            _dataContext = context;
        }

        private async Task<List<CategoriaProducto>>GetCategoriaProductoDB()
        {
            return await _dataContext.categoriaProductos.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaProducto>>> GetAllCategorias()
        {
            var lista = await _dataContext.categoriaProductos
                .Include(e=>e.EstadoProducto)
                .ToListAsync();
            if (lista.Any()) return Ok(lista);

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaProducto>> GetCategoriaProducto(int id)
        {
            var categoria = await _dataContext.categoriaProductos
                .Include(cat=>cat.EstadoProducto)
                .Where(cat=> cat.Id == id)
                .FirstOrDefaultAsync();

            if(categoria == null) return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaProducto>> PostCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            if (categoriaProducto == null) return BadRequest();

            await _dataContext.categoriaProductos.AddAsync(categoriaProducto);
            await _dataContext.SaveChangesAsync();  
            return Ok(GetCategoriaProductoDB());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<CategoriaProducto>> UpdateCategoriaProducto(int id, CategoriaProducto categoriaProducto)
        {
            if (categoriaProducto == null) return BadRequest();

            var cat = await _dataContext.categoriaProductos
                        .Where(cat=> cat.Id==id)
                        .FirstOrDefaultAsync();

            if(cat == null) return NotFound();

            cat.NombreCategoria = categoriaProducto.NombreCategoria;

            await _dataContext.SaveChangesAsync();
            return Ok(GetCategoriaProductoDB());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoriaProducto(int id)
        {
            var cat = await _dataContext.categoriaProductos
                        .Where(cat => cat.Id == id)
                        .FirstOrDefaultAsync();

            if(cat==null) return BadRequest();

            _dataContext.categoriaProductos.Remove(cat);
            await _dataContext.SaveChangesAsync();

            return Ok(GetCategoriaProductoDB());
        }
    }
}
