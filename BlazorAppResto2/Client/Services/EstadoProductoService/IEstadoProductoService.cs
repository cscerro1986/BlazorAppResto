namespace BlazorAppResto2.Client.Services.EstadoProductoService
{
    public interface IEstadoProductoService
    {
        List<EstadoProducto> EstadoProductos { get; set; }
        Task GetEstadoProducto();
        Task<EstadoProducto> GetEstadoProductoById(int id);
        Task CreateEstadoProducto(EstadoProducto estadoProducto);
        Task DeleteEstadoProducto(int id);
        Task UpdateEstadoProducto(int id, EstadoProducto estadoProducto);
    }
}
