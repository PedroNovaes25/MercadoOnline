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

            var users = CreateUsers(_userRepository).Result;
            var orders = new List<Pedido>();
            for (int i = -1; i < 3; i++)
            {
                var user = i < 1 ? users[i*-1] : users[1];
                orders.Add(DataSourcePedido(_pedidoRepository, 20 * (i+1), DateTime.UtcNow.AddDays(1), user).Result);
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
