using BlazorAppResto2.Shared.Models;
namespace BlazorAppResto2.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoProducto>().HasData(
                new EstadoProducto
                {
                    Id = 1,
                    NombreEstado="Vigente"
                },
                new EstadoProducto
                {
                    Id=2,
                    NombreEstado="Discontinuado"
                },
                new EstadoProducto
                {
                    Id=3,
                    NombreEstado="Sin Stock"
                }
            );

            modelBuilder.Entity<CategoriaProducto>().HasData(
                new CategoriaProducto
                {
                    Id = 1,
                    NombreCategoria = "Bebidas",
                    EstadoProductoId = 1
                },
                new CategoriaProducto
                {
                    Id = 2,
                    NombreCategoria = "Hamburguesas",
                    EstadoProductoId = 1
                },
                new CategoriaProducto
                {
                    Id = 3,
                    NombreCategoria = "Pastas",
                    EstadoProductoId = 1
                },
                new CategoriaProducto
                {
                    Id = 4,
                    NombreCategoria = "Postres",
                    EstadoProductoId = 2
                }
            );

            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id=1,
                    NombreProducto="Hamburguesa doble",
                    EstadoProductoId = 1,
                    CategoriaProductoId=2,
                    Importe=1100,
                    Stock=16
                },
                new Producto
                {
                    Id = 2,
                    NombreProducto = "Tiramisu especial",
                    EstadoProductoId = 1,
                    CategoriaProductoId = 4,
                    Importe =850,
                    Stock = 9
                },
                new Producto
                {
                    Id = 3,
                    NombreProducto = "Flan con dulce de leche",
                    EstadoProductoId = 1,
                    CategoriaProductoId = 4,
                    Importe =450,
                    Stock = 10
                },
                new Producto
                {
                    Id = 4,
                    NombreProducto = "Coca Cola",
                    EstadoProductoId = 1,
                    CategoriaProductoId = 1,
                    Importe =350,
                    Stock = 200
                },
                new Producto
                {
                    Id = 5,
                    NombreProducto = "Pepsi 500ml",
                    EstadoProductoId = 1,
                    CategoriaProductoId = 1,
                    Importe =290,
                    Stock = 60
                },
                new Producto
                {
                    Id = 6,
                    NombreProducto = "Ravioles de osobuco",
                    EstadoProductoId = 1,
                    CategoriaProductoId = 3,
                    Importe =1980,
                    Stock = 300
                },
                new Producto
                {
                    Id = 7,
                    NombreProducto = "Lasagna de ricota",
                    EstadoProductoId = 1,
                    CategoriaProductoId = 3,
                    Importe =2590,
                    Stock = 200
                },
                new Producto
                {
                    Id = 8,
                    NombreProducto = "Doble chedar y Cordero",
                    EstadoProductoId = 1,
                    CategoriaProductoId = 2,
                    Importe =1900,
                    Stock = 70
                },
                new Producto
                {
                    Id = 9,
                    NombreProducto = "WTF provoleta y ciruela ",
                    EstadoProductoId = 2,
                    CategoriaProductoId = 2,
                    Importe =2500,
                    Stock = 58
                },
                new Producto
                {
                    Id = 10,
                    NombreProducto = "Raviolon 4 quesos",
                    EstadoProductoId = 2,
                    CategoriaProductoId = 3,
                    Importe = 3456,
                    Stock = 100
                }
            );
        }

        public DbSet<EstadoProducto> estadoProductos { get; set; }
        public DbSet<CategoriaProducto> categoriaProductos { get; set; }
        public DbSet<Producto>productos { get; set; }


    }
}
