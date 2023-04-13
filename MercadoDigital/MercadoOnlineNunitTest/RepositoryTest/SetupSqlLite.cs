using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Domain.IRepositories.Handler;
using MercadoDigital.Infra.Data.Connection;
using MercadoDigital.Infra.Data.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MercadoOnlineNunitTest.RepositoryTest
{
    public class SetupSqlLite
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;
        public readonly DbContextOptions<MercadoDbContext> _contextOptions;
        public MercadoDbContext Context;

        public SetupSqlLite()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();

            _contextOptions = new DbContextOptionsBuilder<MercadoDbContext>()
                .UseSqlite(_connection)
                .Options;

            Context = new MercadoDbContext(_contextOptions);
            Context.Database.EnsureCreated();
        }

        //ok
        public async Task<List<Categoria>> DataSourceCategoria(ICategoriaRepository categoriaRepository)
        {
            foreach (var item in _dataSourceCategories)
            {
                await categoriaRepository.Create(item);
            } 

            return _dataSourceCategories;
        }
        
        //ok
        public async Task<List<Produto>> DataSourceProduto(IProdutoRepository produtoRepository)
        {

            foreach (var item in _dataSourceProdutos)
            {
                await produtoRepository.Create(item);
            }

            return _dataSourceProdutos;
        }

        //ok
        public async Task CreateUser(IUsuarioRepository usuarioRepository, Usuario usuario)
        {
            await usuarioRepository.Create(usuario);
        }
        
        //ok
        public async Task<bool> DataSourceEndereco(IEnderecoRepository enderecoRepository, Endereco endereco)
        {
            return await enderecoRepository.Create(endereco);
        }
        
        //ok
        public async Task<bool> DataSourceEstoque(IEstoqueRepository estoqueRepository, Estoque estoque)
        {
            return await estoqueRepository.CreateOrUpdate(estoque);
        }

        //ok
        public async Task<bool> DataSourcePedido(IPedidoRepository pedidoRepository, Pedido pedido)
        {
            return await pedidoRepository.Create(pedido);
        }

        //
        public async Task<bool> DataSourceCategoriaProduto(ICategoriaProdutoRepository categoriaProdutoRepository, Categoria categoria, Produto produto) 
        {
            var categoriaProduto = new CategoriaProduto(categoria.IdCategoria, produto.IdProduto);
            return await categoriaProdutoRepository.Create(categoriaProduto);
        }

        //ok
        public async Task<bool> DataSourcePedidoItem(IPedidoItemRepository pedidoItemRepository, int quantidade, double subtotal, Pedido pedido, Produto produto)
        {
            var pedidoItem = new PedidoItem(quantidade, subtotal, produto.IdProduto, pedido.IdPedido);
            return await pedidoItemRepository.Create(pedidoItem);
        }

        #region DataSources


        private List<Produto> _dataSourceProdutos = new List<Produto>()
        {
            new Produto("Feijão", new DateTime(2024,06,25), "1kg Feijão Tio João", 8.85),
            new Produto("Arroz", new DateTime(2024,04,06), "1kg Arroz Dona Cinha", 8.10),
            new Produto("Peito de frango", DateTime.UtcNow.AddDays(25), "Preço por 1kg", 15.49),
            new Produto("Filé mion", DateTime.UtcNow.AddDays(20), "Preço por 1kg", 28.5),
            new Produto("Coentro", DateTime.UtcNow.AddDays(5), "Preço por maço de coentro", 4),
            new Produto("Agua sanitária", DateTime.UtcNow.AddDays(5), "1L", 4),
            new Produto("Alcool", DateTime.UtcNow.AddDays(5), "1L", 4)
        };

        private List<Categoria> _dataSourceCategories = new List<Categoria>()
        {
            new Categoria("Carne Vermelha"),
            new Categoria("Carne Branca"),
            new Categoria("Tempero"),
            new Categoria("Hortaliças"),
            new Categoria("Alimento"),
            new Categoria("Limpeza")
        };

        public List<Usuario> SourceUsuarios = new List<Usuario>()
        {
            new Usuario("Felipe", "38405125", "4832562565", new DateTime(2000, 04, 25), IdadeAtual(2000), "M", "119459494", "Felipe@gmail.com", "123456"),
            new Usuario("Pedro", "38405125", "4832562565", new DateTime(2004, 08, 14), IdadeAtual(2004), "M", "119459494", "Pedro@gmail.com", "123456"),
            new Usuario("Paulo", "38405125", "4832562565", new DateTime(2002, 06, 09), IdadeAtual(2002), "M", "119459494", "Paulo@gmail.com", "123456"),
            new Usuario("Rafael", "38405125", "4832562565", new DateTime(1998, 04, 12), IdadeAtual(1998), "M", "119459494", "Rafael@gmail.com", "123456"),
            new Usuario("Alefh", "38405125", "1056545665" ,new DateTime(2003, 05, 20), IdadeAtual(2003), "M", "117899494", "Alefh@gmail.com", "123456"),
            new Usuario("Aloson", "38405125", "4556465656" ,new DateTime(1999, 12, 05), IdadeAtual(1999), "M", "114569494", "Aloson@gmail.com", "123456")
        };

        private static int IdadeAtual(int nascimento)
        {
            return DateTime.Now.Year - nascimento;
        }

        #endregion
    }
}