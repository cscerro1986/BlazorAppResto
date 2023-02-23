using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorAppResto2.Client.Services.CategoriaProductoService
{
    public class CategoriaProductoService : ICategoriaProductoService
    {
        public List<CategoriaProducto> categoriaProductos { get; set; } = new List<CategoriaProducto>();
        public List<EstadoProducto> estadoProductos { get; set; } = new List<EstadoProducto>();

        public readonly HttpClient _http;
        public readonly NavigationManager _navigatorManager;

        public CategoriaProductoService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigatorManager = navigationManager;
        }
        public async Task GetCategoriaProducto()
        {
            var result = await _http.GetFromJsonAsync<List<CategoriaProducto>>("api/CategoriaProducto");
            if(result != null) categoriaProductos=result;

        }

        public async Task GetEstado()
        {
             var results = await _http.GetFromJsonAsync<List<EstadoProducto>>("api/estadoProducto");
                if(results!= null) estadoProductos=results;

        }
        public Task CreateCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoriaProducto(int id)
        {
            throw new NotImplementedException();
        }


        public Task<EstadoProducto> GetEstadoProductoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoriaProducto(int id, CategoriaProducto categoriaProducto)
        {
            throw new NotImplementedException();
        }
    }
}
