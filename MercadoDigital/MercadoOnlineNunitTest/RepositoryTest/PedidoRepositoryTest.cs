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
    internal class PedidoRepositoryTest : SetupSqlLite
    {
        private readonly IUsuarioRepository _userRepository;
        private IPedidoRepository _pedidoRepository;

        public PedidoRepositoryTest()
        {
            _pedidoRepository = new PedidoRepository(_contextOptions);
            _userRepository = new UsuarioRepository(_contextOptions);
            CreatePedido();
        }

        [Test]
        public async Task GetAllExistingPedidoByUserId_ReturnSuccess() 
        {
            int idUser = 1;
            var pedidos = await _pedidoRepository.GetAllPedidosByUserId(idUser);

            Assert.IsNotNull(pedidos);
            Assert.IsTrue(pedidos.Count() > 0);
        }
        [Test]
        public async Task GetPedidoById_ReturnSuccess() 
        {
            int idPedido = 1;
            var pedido = await _pedidoRepository.GetPedidosById(idPedido);

            Assert.IsNotNull(pedido);
        }

        #region Test Data Source

        private void CreatePedido() 
        {
            var user = CreateUsers(_userRepository).Result.First();

            for (int i = -1; i < 3; i++)
            {
                DataSourcePedido(_pedidoRepository, 20 * (i+1), DateTime.UtcNow.AddDays(1), user).Wait();
            }
        }

        #endregion
    }
}
