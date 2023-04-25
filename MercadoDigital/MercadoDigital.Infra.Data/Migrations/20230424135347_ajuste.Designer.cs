﻿// <auto-generated />
using System;
using MercadoDigital.Infra.Data.Connection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MercadoDigital.Infra.Data.Migrations
{
    [DbContext(typeof(MercadoDbContext))]
    [Migration("20230424135347_ajuste")]
    partial class ajuste
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"), 50L, 5);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.CategoriaProduto", b =>
                {
                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.HasKey("IdCategoria", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("CategoriaProduto");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEndereco"), 10L, 5);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEndereco");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Estoque", b =>
                {
                    b.Property<int>("IdEstoque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstoque"), 20L, 5);

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("IdEstoque");

                    b.HasIndex("IdProduto")
                        .IsUnique();

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"), 30L, 5);

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<double>("ValorPedido")
                        .HasColumnType("float");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.PedidoItem", b =>
                {
                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    b.HasKey("IdPedido", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("PedidoItem");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduto"), 40L, 5);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("IdProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 60L, 5);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.CategoriaProduto", b =>
                {
                    b.HasOne("MercadoDigital.Domain.Entities.Categoria", "Categoria")
                        .WithMany("CategoriaProduto")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MercadoDigital.Domain.Entities.Produto", "Produto")
                        .WithMany("CategoriaProduto")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("MercadoDigital.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Endereco")
                        .HasForeignKey("MercadoDigital.Domain.Entities.Endereco", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Estoque", b =>
                {
                    b.HasOne("MercadoDigital.Domain.Entities.Produto", "Produto")
                        .WithOne("Estoque")
                        .HasForeignKey("MercadoDigital.Domain.Entities.Estoque", "IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("MercadoDigital.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.PedidoItem", b =>
                {
                    b.HasOne("MercadoDigital.Domain.Entities.Pedido", "Pedido")
                        .WithMany("PedidoItem")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MercadoDigital.Domain.Entities.Produto", "Produto")
                        .WithMany("PedidoItem")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("CategoriaProduto");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("PedidoItem");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Produto", b =>
                {
                    b.Navigation("CategoriaProduto");

                    b.Navigation("Estoque")
                        .IsRequired();

                    b.Navigation("PedidoItem");
                });

            modelBuilder.Entity("MercadoDigital.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
