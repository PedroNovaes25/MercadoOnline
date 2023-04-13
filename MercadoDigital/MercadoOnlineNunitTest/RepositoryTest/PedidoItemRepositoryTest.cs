using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoOnlineNunitTest.RepositoryTest
{
    internal class PedidoItemRepositoryTest : SetupSqlLite
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _ProdutoRepository;
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly UsuarioRepository _userRepository;

        public PedidoItemRepositoryTest()
        {
            _pedidoRepository = new PedidoRepository(_contextOptions);
            _ProdutoRepository = new ProdutoRepository(_contextOptions);
            _pedidoItemRepository = new PedidoItemRepository(_contextOptions);
            _userRepository = new UsuarioRepository(_contextOptions);

            CreateOrderItem();
        }

        [Test]
        public async Task GettingPedidos_CheckingLinkedOrderItems_LinkedSuccess() 
        {
            var orderItems = await _pedidoRepository.GetAllPedidosByUserId(2);

            Assert.IsNotNull(orderItems);

            foreach (var item in orderItems)
            {
                Assert.That(item.PedidoItem.First()?.IdPedido, Is.EqualTo(item.IdPedido));
            }
        }

        #region Test Data Source

        private void CreateOrderItem() 
        {
            //setup
            var produtos = DataSourceProduto(_ProdutoRepository).Result;
            var orders = new List<Pedido>();


            foreach (var item in SourceUsuarios)
            {
                CreateUser(_userRepository, item).Wait();
            }

            for (int i = -1; i < 3; i++)
            {
                var user = i < 1 ? SourceUsuarios[i*-1] : SourceUsuarios[1];

                var order = new Pedido(20 * (i + 1), DateTime.UtcNow.AddDays(1), user.IdUsuario);
                DataSourcePedido(_pedidoRepository, order).Wait();
                orders.Add(order);
            }


            //create
            for (int i = 0; i < 4; i++)
            {
                DataSourcePedidoItem(_pedidoItemRepository, (i+2-1), (i + 2 - 1) * orders[i].ValorPedido , orders[i], produtos[i]).Wait();
            }
        }

        #endregion
    }
}
