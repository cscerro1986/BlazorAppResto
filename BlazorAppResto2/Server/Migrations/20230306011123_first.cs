using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorAppResto2.Server.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoriaProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "estadoProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoProductoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaProductoId = table.Column<int>(type: "int", nullable: false),
                    Importe = table.Column<float>(type: "real", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productos_categoriaProductos_CategoriaProductoId",
                        column: x => x.CategoriaProductoId,
                        principalTable: "categoriaProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productos_estadoProductos_EstadoProductoId",
                        column: x => x.EstadoProductoId,
                        principalTable: "estadoProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categoriaProductos",
                columns: new[] { "Id", "NombreCategoria" },
                values: new object[,]
                {
                    { 1, "Bebidas" },
                    { 2, "Hamburguesas" },
                    { 3, "Pastas" },
                    { 4, "Postres" }
                });

            migrationBuilder.InsertData(
                table: "estadoProductos",
                columns: new[] { "Id", "NombreEstado" },
                values: new object[,]
                {
                    { 1, "Vigente" },
                    { 2, "Discontinuado" },
                    { 3, "Sin Stock" }
                });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "Id", "CategoriaProductoId", "EstadoProductoId", "Importe", "NombreProducto", "Stock" },
                values: new object[,]
                {
                    { 1, 2, 1, 1100f, "Hamburguesa doble", 16 },
                    { 2, 4, 1, 850f, "Tiramisu especial", 9 },
                    { 3, 4, 1, 450f, "Flan con dulce de leche", 10 },
                    { 4, 1, 1, 350f, "Coca Cola", 200 },
                    { 5, 1, 1, 290f, "Pepsi 500ml", 60 },
                    { 6, 3, 1, 1980f, "Ravioles de osobuco", 300 },
                    { 7, 3, 1, 2590f, "Lasagna de ricota", 200 },
                    { 8, 2, 1, 1900f, "Doble chedar y Cordero", 70 },
                    { 9, 2, 2, 2500f, "WTF provoleta y ciruela ", 58 },
                    { 10, 3, 2, 3456f, "Raviolon 4 quesos", 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_productos_CategoriaProductoId",
                table: "productos",
                column: "CategoriaProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_EstadoProductoId",
                table: "productos",
                column: "EstadoProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "categoriaProductos");

            migrationBuilder.DropTable(
                name: "estadoProductos");
        }
    }
}
