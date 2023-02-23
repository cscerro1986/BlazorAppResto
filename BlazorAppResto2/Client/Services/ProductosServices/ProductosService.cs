using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorAppResto2.Client.Services.ProductosServices
{
    public class ProductosService : IProductosService
    {

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public ProductosService(HttpClient httpClient, NavigationManager navigation)
        {
            _httpClient= httpClient;
            _navigationManager= navigation;
        }


        public List<Producto> Productos { get; set; }= new List<Producto>();
        public List<CategoriaProducto> Categorias { get; set; }= new List<CategoriaProducto>();
        public List<EstadoProducto> Estados { get; set; }= new List<EstadoProducto>();

        public async Task GetProductos()
        {
            var results = await _httpClient.GetFromJsonAsync<List<Producto>>("api/Producto");
                if(results!=null) Productos= results;
        }
        public async Task GetCategoriaProducto()
        {
            var results = await _httpClient.GetFromJsonAsync<List<CategoriaProducto>>("api/CategoriaProducto");
            if (results != null) Categorias = results;
        }

        public async Task GetEstadoProducto()
        {
            var results = await _httpClient.GetFromJsonAsync<List<EstadoProducto>>("api/EstadoProducto");
            if (results != null) Estados = results;
        }
        
        public async Task<Producto> GetProductoById(int id)
        {
            var results = await _httpClient.GetFromJsonAsync<Producto>($"api/Producto/{id}");
            if (results!=null) return results;

            throw new Exception("Producto no encontrado!!!");
        }

        public async Task CreateProducto(Producto entity)
        {
            var results = await _httpClient.PostAsJsonAsync("api/Producto", entity);
            
        }

        public async Task DeleteProducto(int id)
        {
            var results = await _httpClient.DeleteAsync($"api/Producto/{id}");
        }
        
        public async Task UpdateProducto(Producto entity)
        {
            var results = await _httpClient.PostAsJsonAsync($"api/Producto/{entity.Id}",entity);
        }
    }
}
