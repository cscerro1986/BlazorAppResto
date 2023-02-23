namespace BlazorAppResto2.Client.Services.ProductosServices
{
    public interface IProductosService
    {
        List<Producto> Productos { get; set; }
        List<CategoriaProducto> Categorias { get; set; }
        List<EstadoProducto> Estados { get; set; }
        Task GetProductos();
        Task GetCategoriaProducto();
        Task GetEstadoProducto();
        Task <Producto> GetProductoById(int id);
        Task CreateProducto(Producto entity);
        Task UpdateProducto(Producto entity);
        Task DeleteProducto(int id);

    }
}
