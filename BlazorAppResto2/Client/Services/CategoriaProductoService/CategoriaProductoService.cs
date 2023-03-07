using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorAppResto2.Client.Services.CategoriaProductoService
{
    public class CategoriaProductoService : ICategoriaProductoService
    {
        public List<CategoriaProducto> categoriaProductos { get; set; } = new List<CategoriaProducto>();

        public readonly HttpClient _http;
        public readonly NavigationManager _navigatorManager;

        public CategoriaProductoService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigatorManager = navigationManager;
        }

        private async Task SetCategoriaProducto(HttpResponseMessage results)
        {
            Console.WriteLine("Entro al setCategoria");
            Console.WriteLine("Contenido de results"+results.StatusCode.ToString());
            Console.WriteLine("Contenido de results"+results.Content.ToString());

            var response = await results.Content.ReadFromJsonAsync<List<CategoriaProducto>>();
            Console.WriteLine("Paso el ReadFromJsonAsync"+ response.Count);
            categoriaProductos = response;
            _navigatorManager.NavigateTo("/ListadoCategorias");

        }
        public async Task GetCategoriaProducto()
        {
            var result = await _http.GetFromJsonAsync<List<CategoriaProducto>>("api/CategoriaProducto");
            if(result != null) categoriaProductos=result;

        }

       
        public async Task CreateCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            Console.WriteLine("Entro al CreateCategoria");
            var results = await _http.PostAsJsonAsync($"api/CategoriaProducto", categoriaProducto);
            Console.WriteLine("algo:"+results.Content.ToString());

            Console.WriteLine("paso el postAsJsonAsync" +results.IsSuccessStatusCode.ToString());
            await SetCategoriaProducto(results);

        }

        public async Task DeleteCategoriaProducto(int id)
        {
            var results = await _http.DeleteAsync($"api/CategoriaProducto/{id}");
            await SetCategoriaProducto(results);
        }


        public async Task<CategoriaProducto> GetCategoriaProductoByID(int id)
        {
            var results = await _http.GetFromJsonAsync<CategoriaProducto>($"api/categoriaProducto/{id}");
            if (results != null) return results;

            throw new Exception("No se encontro la categoria buscada");
        }

        public async Task UpdateCategoriaProducto(int id, CategoriaProducto categoriaProducto)
        {
            var results = await _http.PostAsJsonAsync($"api/CategoriaProducto/{id}", categoriaProducto);
            Console.WriteLine("el estatus code es: " + results.Content.ToString());
            Console.WriteLine("el estatus code es: " + results.StatusCode.ToString());
            await SetCategoriaProducto(results);
        }
    }
}
