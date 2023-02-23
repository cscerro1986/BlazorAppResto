using BlazorAppResto2.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppResto2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductoController(DataContext context)
        {
            _context = context;
        }

        private async Task <ActionResult<List<Producto>>>GetProductoDB()
        {
            return await _context.productos.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>>GetProducto()
        {

            var productos = await _context.productos
                                   .Include(p => p.CategoriaProducto)
                                   .Include(p => p.EstadoProducto)
                                   .ToListAsync();

            if(productos==null) return NotFound();
                
                return Ok(productos);

            //var query = from a in _context.productos
            //            join s in _context.estadoProductos on a.EstadoProductoId equals s.Id
            //            join c in _context.categoriaProductos on a.CategoriaProductoId equals c.Id
            //            select new RetornoProducto
            //            {
            //                Id = a.Id,
            //                Name = a.NombreProducto,
            //                Stock = a.Stock,
            //                Importe = a.Importe,
            //                Categoria = c.NombreCategoria,
            //                Estado = s.NombreEstado
            //            };

            //            return Ok(query.ToList());  

        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.productos
                            .Where(p => p.Id == id)
                            .Include(p => p.EstadoProducto)
                            .Include(p => p.CategoriaProducto)
                            .ToListAsync();
            if( producto== null) return NotFound();

            return Ok(producto);
                            
        }

        [HttpPost]
        public async Task<ActionResult<List<Producto>>>CreateProducto(Producto producto)
        {
            producto.EstadoProducto = null;
            producto.CategoriaProducto = null;
            var response = await _context.productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return Ok(GetProductoDB());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<List<Producto>>> UpdateProducto(int id, Producto producto)
        {
            if (producto == null) return BadRequest();

            var prod = await _context.productos
                            .Where(p => p.Id == id)
                            .FirstOrDefaultAsync();

            if (prod == null) return NotFound();

            prod.Importe = producto.Importe;
            prod.Stock = producto.Stock;
            prod.NombreProducto = producto.NombreProducto;
            prod.EstadoProductoId = producto.EstadoProductoId;
            prod.CategoriaProductoId = producto.CategoriaProductoId;
            
            await _context.SaveChangesAsync();
            return Ok(GetProductoDB());


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Producto>>> DeleteProducto(int id)
        {
            var prod = await _context.productos
                            .Where(p => p.Id == id)
                            .FirstOrDefaultAsync();

            _context.productos.Remove(prod);
            await _context.SaveChangesAsync();

            return Ok(GetProductoDB());

        }

        public class RetornoProducto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Stock { get; set; }  
            public float Importe { get; set; }  
            public string Categoria { get; set; }
            public string Estado { get; set; }

        }         
    }
}
