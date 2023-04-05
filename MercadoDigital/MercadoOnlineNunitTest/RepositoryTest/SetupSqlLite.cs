using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Connection;
using MercadoDigital.Infra.Data.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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


        public async Task<List<Categoria>> DataSourceCategoria(ICategoriaRepository categoriaRepository)
        {
            foreach (var categoria in _dataSourceCategoria)
            {
                await categoriaRepository.Create(categoria);
            }
            return _dataSourceCategoria;
        }
        public async Task<List<Produto>> DataSourceProduto(IProdutoRepository categoriaRepository)
        {
           
            foreach (var item in _dataSourceProdutos)
            {
                await categoriaRepository.Create(item);
            }

            return _dataSourceProdutos;
        }
        public async Task<IEnumerable<Usuario>> DataSourceUsuario(IUsuarioRepository usuarioRepository)
        {
            foreach (var item in _dataSourceUsuario)
            {
                await usuarioRepository.Create(item);
            }

            return _dataSourceUsuario;
        }
        public async Task DataSourceEndereco(IEnderecoRepository enderecoRepository)
        {
            var _usuarioRepository = new UsuarioRepository(_contextOptions);
            var users = (await DataSourceUsuario(_usuarioRepository)).ToList();

            var enderecos = new List<Endereco>()
            {
                new Endereco("12345678", "Rua 1", 15, "Bairro A", "Cidade A", "TO", users[0].IdUsuario),
                new Endereco("87654321", "Rua 2", 14, "Bairro B", "Cidade B", "MS", users[1].IdUsuario),
                new Endereco("123654789", "Rua 3", 16, "Bairro C", "Cidade C", "MT", users[2].IdUsuario),
                new Endereco("987456123", "Rua 4", 16, "Bairro D", "Cidade D", "MG", users[3].IdUsuario),
            };

            foreach (var item in enderecos)
            {
                await enderecoRepository.Create(item);
            }
        }
        public async Task<List<Estoque>> DataSourceEstoque(IEstoqueRepository estoqueRepository) 
        {
            var produtos = await DataSourceProduto(new ProdutoRepository(_contextOptions));
            
            var estoques = new List<Estoque>()
            {
                new Estoque(10, produtos[0].IdProduto),
                new Estoque(10, produtos[1].IdProduto),
                new Estoque(10, produtos[2].IdProduto),
                new Estoque(10, produtos[3].IdProduto),
                new Estoque(10, produtos[4].IdProduto),
            };

            foreach (var item in estoques)
            {
                await estoqueRepository.CreateOrUpdate(item);
            }

            return estoques;
        }
        public async Task<List<Pedido>> DataSourcePedido(IPedidoRepository pedidoRepository) 
        {
            var users = (await DataSourceUsuario(new UsuarioRepository(_contextOptions))).ToList();
            var pedidos = new List<Pedido>()
            {
                new Pedido(50, DateTime.UtcNow, users[0].IdUsuario),
                new Pedido(45, DateTime.UtcNow.AddDays(-2), users[1].IdUsuario),
                new Pedido(23, DateTime.UtcNow.AddDays(-2), users[0].IdUsuario),
                new Pedido(50, DateTime.UtcNow.AddDays(-2), users[3].IdUsuario)
            };

            foreach (var item in pedidos)
            {
                await pedidoRepository.Create(item);
            }

            return pedidos;
        }

        #region DataSources

        private List<Categoria> _dataSourceCategoria = new List<Categoria>()
        {
            new Categoria("Carne Vermelha"),
            new Categoria("Carne Branca"),
            new Categoria("Hortaliças"),
            new Categoria("Tempero"),
            new Categoria("Limpeza"),
            new Categoria("Elétrica"),
            new Categoria("Frios"),
            new Categoria("Laticionio")
        };
        public List<Produto> _dataSourceProdutos = new List<Produto>()
        {
            new Produto("Feijão", new DateTime(2024,06,25), "1kg Feijão Tio João", 8.85),    
            new Produto("Arroz", new DateTime(2024,04,06), "1kg Arroz Dona Cinha", 8.10),    
            new Produto("Peito de frango", DateTime.UtcNow.AddDays(25), "Preço por 1kg", 15.49),    
            new Produto("Filé mion", DateTime.UtcNow.AddDays(20), "Preço por 1kg", 28.5),    
            new Produto("Coentro", DateTime.UtcNow.AddDays(5), "Preço por maço de coentro", 4),    
        };
        private List<Usuario> _dataSourceUsuario = new List<Usuario>()
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