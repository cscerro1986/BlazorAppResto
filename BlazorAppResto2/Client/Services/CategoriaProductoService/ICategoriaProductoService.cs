namespace BlazorAppResto2.Client.Services.CategoriaProductoService
{
    public interface ICategoriaProductoService
    {

        List<CategoriaProducto> categoriaProductos { get; set; }
        List<EstadoProducto> estadoProductos { get; set; }  
        Task GetCategoriaProducto();
        Task GetEstado();
        Task<EstadoProducto> GetEstadoProductoById(int id);
        Task CreateCategoriaProducto(CategoriaProducto categoriaProducto);
        Task DeleteCategoriaProducto(int id);
        Task UpdateCategoriaProducto(int id, CategoriaProducto categoriaProducto);
    }
}
