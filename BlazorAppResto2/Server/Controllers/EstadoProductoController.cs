using Microsoft.AspNetCore.Http;
using BlazorAppResto2.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppResto2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoProductoController : ControllerBase
    {
        private readonly DataContext _context;
        public EstadoProductoController(DataContext context)
        {
            _context = context;
        }

        private async Task<List<EstadoProducto>> GetEstadoProductoDB()
        {
            return await _context.estadoProductos.ToListAsync();
        }

        [HttpGet]
        public async Task <ActionResult<List<EstadoProducto>>>GetEstadoProducto()
        {
            var estados = await _context.estadoProductos.ToListAsync();
            if(estados.Any()) return Ok(estados);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoProducto>> GetEstadoProducto(int id)
        {
            var estados = await _context.estadoProductos
                .Where(ep => ep.Id == id)
                .FirstOrDefaultAsync();
            if (estados!=null) return Ok(estados);

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<List<EstadoProducto>>>CreateEstadoProducto(EstadoProducto estadoProducto)
        {           
            var dbResponse = await _context.estadoProductos.AddAsync(estadoProducto);
            await _context.SaveChangesAsync();
            return Ok(await GetEstadoProductoDB());
        }

        [HttpPost ("{id}")]
        public async Task<ActionResult<List<EstadoProducto>>> UpdateEstadoProducto(int id, EstadoProducto estadoProducto)
        {
           var estadoProductoDB = await _context.estadoProductos
                                    .Where(esta => esta.Id == id)
                                    .FirstOrDefaultAsync();

            if(estadoProductoDB ==null)
            {
                    return NotFound("No se pudo");
            }
            else
            {
                try
                {
                    estadoProductoDB.NombreEstado = estadoProducto.NombreEstado;
                    await _context.SaveChangesAsync();
                    return Ok(await GetEstadoProductoDB());
                }
                catch (Exception)
                {
                    return StatusCode(407);
                }
            }                                        
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<EstadoProducto>>> DeleteEstadoProducto(int id)
        {
            var estadoProductoDB = await _context.estadoProductos
                                        .FirstOrDefaultAsync(ep => ep.Id == id);

            _context.estadoProductos.Remove(estadoProductoDB);
            await _context.SaveChangesAsync();

            return Ok(await GetEstadoProductoDB());
        }

    }
}
