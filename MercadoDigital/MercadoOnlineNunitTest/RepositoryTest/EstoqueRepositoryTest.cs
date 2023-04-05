using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.Models;
using MercadoDigital.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoOnlineNunitTest.RepositoryTest
{
    internal class EstoqueRepositoryTest : SetupSqlLite
    {
        private EstoqueRepository _estoqueRepository;

        public EstoqueRepositoryTest()
        {
            _estoqueRepository = new EstoqueRepository(_contextOptions);
            DataSourceEstoque(_estoqueRepository).Wait();
        }

        [Test]
        public async Task GetAllEstoque()
        {
            var estoques = await _estoqueRepository.GetAllEstoque();
            Assert.IsNotNull(estoques);
            Assert.IsTrue(estoques.Count() > 0);
        }

        [Test]
        public async Task GetEstoqueById()
        {
            var idEstoque = 2;
            var estoqueExiste = await _estoqueRepository.GetEstoqueById(idEstoque);
            Assert.IsNotNull(estoqueExiste);

            var estoqueNaoExiste = await _estoqueRepository.GetEstoqueById(100);
            Assert.IsNull(estoqueNaoExiste);

        }

        [Test]
        public async Task GetEstoqueByProductId()
        {
            var idProduto = 2;
            var estoqueExiste = await _estoqueRepository.GetEstoqueByProductId(idProduto);
            Assert.IsNotNull(estoqueExiste);
        }

        [Test]
        public async Task Update()
        {
            var idEstoque = 3;
            var qtdEstoque = 4;
            var estoqueExistente = await _estoqueRepository.GetEstoqueById(idEstoque);
            Assert.IsNotNull(estoqueExistente);

            var estoqueParaAtualizar = new Estoque(estoqueExistente.IdEstoque, qtdEstoque, estoqueExistente.IdProduto);
            var estoqueAtualizado = await _estoqueRepository.CreateOrUpdate(estoqueParaAtualizar);

            Assert.IsTrue(estoqueAtualizado);
            Assert.IsTrue(estoqueParaAtualizar.IdEstoque == idEstoque);
        }

        [Test]
        public async Task Delete()
        {
            var idEstoque = 1;
            var estoqueExistente = await _estoqueRepository.GetEstoqueById(idEstoque);
            var estoqueParaDeletar = new Estoque(estoqueExistente.IdEstoque, estoqueExistente.Quantidade, estoqueExistente.IdProduto);
            
            var deletado = await _estoqueRepository.Delete(estoqueParaDeletar);
            Assert.IsTrue(deletado);
            
            var conferindoDelecao = await _estoqueRepository.GetEstoqueById(idEstoque);
            Assert.IsNull(conferindoDelecao);

        }
    }
}
