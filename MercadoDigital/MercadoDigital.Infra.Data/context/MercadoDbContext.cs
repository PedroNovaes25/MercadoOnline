using MercadoDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MercadoDigital.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MercadoDigital.Infra.Data.Connection
{
    public class MercadoDbContext : IdentityUserContext<User, int>
    {
        public MercadoDbContext()
        {
        }

        public MercadoDbContext(DbContextOptions<MercadoDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Estoque> Estoques { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            { 
                var sourceDbTemp = "Data Source=DESKTOP-IIHJ6QS;Initial Catalog=MercadoOnlineDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                options.UseSqlServer(sourceDbTemp);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


           // modelBuilder.Entity<UserRole>(userRole =>
           // {
           //     userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

           //     userRole.HasOne(ur => ur.Role)
           //         .WithMany(r => r.UserRoles)
           //         .HasForeignKey(ur => ur.RoleId)
           //         .IsRequired();

           //     userRole.HasOne(ur => ur.User)
           //       .WithMany(r => r.UserRoles)
           //       .HasForeignKey(ur => ur.UserId)
           //       .IsRequired();
           // }
           //);

            //Config PrimaryKey
            modelBuilder.Entity<Endereco>().HasKey(c => c.IdEndereco);
            modelBuilder.Entity<Endereco>().Property(e => e.IdEndereco)
                .UseIdentityColumn(seed: 10, increment: 5);

            modelBuilder.Entity<Estoque>().HasKey(c => c.IdEstoque);
            modelBuilder.Entity<Estoque>().Property(e => e.IdEstoque)
                .UseIdentityColumn(seed: 20, increment: 5);

            modelBuilder.Entity<Pedido>().HasKey(c => c.IdPedido);
            modelBuilder.Entity<Pedido>().Property(e => e.IdPedido)
                .UseIdentityColumn(seed: 30, increment: 5);

            modelBuilder.Entity<Produto>().HasKey(c => c.IdProduto);
            modelBuilder.Entity<Produto>().Property(e => e.IdProduto)
                .UseIdentityColumn(seed: 40, increment: 5);

            modelBuilder.Entity<Categoria>().HasKey(c => c.IdCategoria);
            modelBuilder.Entity<Categoria>().Property(e => e.IdCategoria)
              .UseIdentityColumn(seed: 50, increment: 5);
            
            //
            //modelBuilder.Entity<User>().HasKey(c => c.Id);
            //modelBuilder.Entity<User>().Property(e => e.Id)
            //  .UseIdentityColumn(seed: 60, increment: 5);

            modelBuilder.Entity<CategoriaProduto>()
            .HasKey(k => new { k.IdCategoria, k.IdProduto });

            modelBuilder.Entity<PedidoItem>()
            .HasKey(k => new { k.IdPedido, k.IdProduto });

            //Usuario Endereco
            modelBuilder.Entity<User>()
                .HasOne(ue => ue.Addresses)
                .WithOne(eu => eu.User)
                .HasForeignKey<Endereco>(eu => eu.UserId);

            //Produto Estoque
            modelBuilder.Entity<Produto>()
                .HasOne(pe => pe.Estoque)
                .WithOne(ep => ep.Produto)
                .HasForeignKey<Estoque>(ep => ep.IdProduto);

            //Pedido Usuario
            modelBuilder.Entity<User>()
                .HasMany(up => up.Orders)
                .WithOne(pu => pu.User)
                .HasForeignKey(pu => pu.UserId);

            //CategoriaProduto Produto
            //CategoriaProduto Categoria
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
