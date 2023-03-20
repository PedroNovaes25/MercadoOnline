using MercadoDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Infra.Data.Context
{
    public class MercadoDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }

        public string DbPath { get; }

        public MercadoDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Usuario Endereco
            modelBuilder.Entity<Usuario>()
                .HasOne(ue => ue.Endereco)
                .WithOne(eu => eu.Usuario)
                .HasForeignKey<Endereco>(eu => eu.IdUsuario);

            modelBuilder.Entity<Endereco>().HasKey(c => c.IdEndereco);
            modelBuilder.Entity<Estoque>().HasKey(c => c.IdEstoque);
            modelBuilder.Entity<Pedido>().HasKey(c => c.IdPedido);
            modelBuilder.Entity<Produto>().HasKey(c => c.IdProduto);
            modelBuilder.Entity<Categoria>().HasKey(c => c.IdCategoria);
            modelBuilder.Entity<Usuario>().HasKey(c => c.IdUsuario);


            //Produto Estoque
            modelBuilder.Entity<Produto>()
                .HasOne(pe => pe.Estoque)
                .WithOne(ep => ep.Produto)
                .HasForeignKey<Estoque>(ep => ep.IdProduto);

            //Pedido Usuario
            modelBuilder.Entity<Usuario>()
                .HasOne(up => up.Pedido)
                .WithOne(pu => pu.Usuario)
                .HasForeignKey<Pedido>(pu => pu.IdUsuario);

            //CategoriaProduto Produto
            //CategoriaProduto Categoria
            modelBuilder.Entity<CategoriaProduto>()
                .HasKey(k => new { k.IdCategoria, k.IdProduto });

            modelBuilder.Entity<CategoriaProduto>()
                .HasOne(cpp => cpp.Categoria)
                .WithMany(pcp => pcp.CategoriaProduto)
                .HasForeignKey(cpp => cpp.IdCategoria);

            modelBuilder.Entity<CategoriaProduto>()
                .HasOne(cpp => cpp.Produto)
                .WithMany(pcp => pcp.CategoriaProduto)
                .HasForeignKey(cpp => cpp.IdProduto);

            //PedidoItem Pedido
            //PedidoItem Produto
            modelBuilder.Entity<PedidoItem>()
                .HasKey(k => new { k.IdPedido, k.IdProduto });

            modelBuilder.Entity<PedidoItem>()
                .HasOne(pip => pip.Pedido)
                .WithMany(ppi => ppi.PedidoItem)
                .HasForeignKey(pip => pip.IdPedido);

            modelBuilder.Entity<PedidoItem>()
                .HasOne(pip => pip.Produto)
                .WithMany(ppi => ppi.PedidoItem)
                .HasForeignKey(pip => pip.IdProduto);

        }

    }
}
