using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorAppResto2.Client.Services.EstadoProductoService
{
    public class EstadoProductoService : IEstadoProductoService
    {
        public List<EstadoProducto> EstadoProductos { get; set; } = new List<EstadoProducto>();

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public EstadoProductoService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        private async Task SetEstadoProducto(HttpResponseMessage results)
        {
            var response = await results.Content.ReadFromJsonAsync<List<EstadoProducto>>();
            EstadoProductos = response;
            _navigationManager.NavigateTo("/listadoEstados");

        }
        public async  Task<EstadoProducto> GetEstadoProductoById(int id)
        {
            var result = await _http.GetFromJsonAsync<EstadoProducto>($"api/EstadoProducto/{id}");
            if (result != null) return result;

            throw new Exception("Estado no encontrado!!!");
        }

        public async Task GetEstadoProducto()
        {
            var retulst = await _http.GetFromJsonAsync<List<EstadoProducto>>("api/EstadoProducto");
            if (retulst != null)
                EstadoProductos = retulst;
        }

        public async Task CreateEstadoProducto(EstadoProducto estadoProducto)
        {            
            var result = await _http.PostAsJsonAsync("api/EstadoProducto", estadoProducto);
            await SetEstadoProducto(result);
        }

        public async Task DeleteEstadoProducto(int id)
        {
            var result = await _http.DeleteAsync($"api/EstadoProducto/{id}");
            _navigationManager.NavigateTo("/listadoEstados");
        }


        public async Task UpdateEstadoProducto(int id, EstadoProducto estadoProducto)
        {
            var results = await _http.PutAsJsonAsync($"api/EstadoProducto/{id}",estadoProducto);
            await SetEstadoProducto(results);
        }
    }
}
