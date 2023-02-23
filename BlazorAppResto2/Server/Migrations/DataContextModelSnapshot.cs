﻿// <auto-generated />
using BlazorAppResto2.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorAppResto2.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorAppResto2.Shared.Models.CategoriaProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstadoProductoId")
                        .HasColumnType("int");

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoProductoId");

                    b.ToTable("categoriaProductos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EstadoProductoId = 1,
                            NombreCategoria = "Bebidas"
                        },
                        new
                        {
                            Id = 2,
                            EstadoProductoId = 1,
                            NombreCategoria = "Hamburguesas"
                        },
                        new
                        {
                            Id = 3,
                            EstadoProductoId = 1,
                            NombreCategoria = "Pastas"
                        },
                        new
                        {
                            Id = 4,
                            EstadoProductoId = 2,
                            NombreCategoria = "Postres"
                        });
                });

            modelBuilder.Entity("BlazorAppResto2.Shared.Models.EstadoProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("estadoProductos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NombreEstado = "Vigente"
                        },
                        new
                        {
                            Id = 2,
                            NombreEstado = "Discontinuado"
                        },
                        new
                        {
                            Id = 3,
                            NombreEstado = "Sin Stock"
                        });
                });

            modelBuilder.Entity("BlazorAppResto2.Shared.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaProductoId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoProductoId")
                        .HasColumnType("int");

                    b.Property<float>("Importe")
                        .HasColumnType("real");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaProductoId");

                    b.HasIndex("EstadoProductoId");

                    b.ToTable("productos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaProductoId = 2,
                            EstadoProductoId = 1,
                            Importe = 1100f,
                            NombreProducto = "Hamburguesa doble",
                            Stock = 16
                        },
                        new
                        {
                            Id = 2,
                            CategoriaProductoId = 4,
                            EstadoProductoId = 1,
                            Importe = 850f,
                            NombreProducto = "Tiramisu especial",
                            Stock = 9
                        },
                        new
                        {
                            Id = 3,
                            CategoriaProductoId = 4,
                            EstadoProductoId = 1,
                            Importe = 450f,
                            NombreProducto = "Flan con dulce de leche",
                            Stock = 10
                        },
                        new
                        {
                            Id = 4,
                            CategoriaProductoId = 1,
                            EstadoProductoId = 1,
                            Importe = 350f,
                            NombreProducto = "Coca Cola",
                            Stock = 200
                        },
                        new
                        {
                            Id = 5,
                            CategoriaProductoId = 1,
                            EstadoProductoId = 1,
                            Importe = 290f,
                            NombreProducto = "Pepsi 500ml",
                            Stock = 60
                        },
                        new
                        {
                            Id = 6,
                            CategoriaProductoId = 3,
                            EstadoProductoId = 1,
                            Importe = 1980f,
                            NombreProducto = "Ravioles de osobuco",
                            Stock = 300
                        },
                        new
                        {
                            Id = 7,
                            CategoriaProductoId = 3,
                            EstadoProductoId = 1,
                            Importe = 2590f,
                            NombreProducto = "Lasagna de ricota",
                            Stock = 200
                        },
                        new
                        {
                            Id = 8,
                            CategoriaProductoId = 2,
                            EstadoProductoId = 1,
                            Importe = 1900f,
                            NombreProducto = "Doble chedar y Cordero",
                            Stock = 70
                        },
                        new
                        {
                            Id = 9,
                            CategoriaProductoId = 2,
                            EstadoProductoId = 2,
                            Importe = 2500f,
                            NombreProducto = "WTF provoleta y ciruela ",
                            Stock = 58
                        },
                        new
                        {
                            Id = 10,
                            CategoriaProductoId = 3,
                            EstadoProductoId = 2,
                            Importe = 3456f,
                            NombreProducto = "Raviolon 4 quesos",
                            Stock = 100
                        });
                });

            modelBuilder.Entity("BlazorAppResto2.Shared.Models.CategoriaProducto", b =>
                {
                    b.HasOne("BlazorAppResto2.Shared.Models.EstadoProducto", "EstadoProducto")
                        .WithMany()
                        .HasForeignKey("EstadoProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoProducto");
                });

            modelBuilder.Entity("BlazorAppResto2.Shared.Models.Producto", b =>
                {
                    b.HasOne("BlazorAppResto2.Shared.Models.CategoriaProducto", "CategoriaProducto")
                        .WithMany()
                        .HasForeignKey("CategoriaProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorAppResto2.Shared.Models.EstadoProducto", "EstadoProducto")
                        .WithMany()
                        .HasForeignKey("EstadoProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaProducto");

                    b.Navigation("EstadoProducto");
                });
#pragma warning restore 612, 618
        }
    }
}
