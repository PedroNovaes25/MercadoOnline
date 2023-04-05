using MercadoDigital.Domain.Entities;
using MercadoDigital.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoOnlineNunitTest.RepositoryTest
{
    internal class PedidoRepositoryTest : SetupSqlLite
    {
        private PedidoRepository _pedidoRepository;

        public PedidoRepositoryTest()
        {
            _pedidoRepository = new PedidoRepository(_contextOptions);
            DataSourcePedido(_pedidoRepository).Wait();
        }

        [Test]
        public async Task GetAllPedidoByUserId() 
        {
            int idUser = 1;
            var pedidos = await _pedidoRepository.GetAllPedidoByUserId(idUser);

            Assert.IsNotNull(pedidos);
            Assert.IsTrue(pedidos.Count() > 0);
        }
        [Test]
        public async Task GetPedidoById() 
        {
            int idPedido = 1;
            var pedido = await _pedidoRepository.GetPedidoById(idPedido);

            Assert.IsNotNull(pedido);
        }
    }
}
