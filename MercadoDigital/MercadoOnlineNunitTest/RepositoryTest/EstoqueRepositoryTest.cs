using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Domain.Models;
using MercadoDigital.Infra.Data.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoOnlineNunitTest.RepositoryTest
{
    internal class EstoqueRepositoryTest : SetupSqlLite
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IProdutoRepository _produtoRepository;

        public EstoqueRepositoryTest()
        {
            _estoqueRepository = new EstoqueRepository(_contextOptions);
            _produtoRepository = new ProdutoRepository(_contextOptions);
            CreateEstoque();
        }

        [Test]
        public async Task ReturnAllExistingEstoques_ReturnSuccess()
        {
            var estoques = await _estoqueRepository.GetAllEstoque();
            Assert.IsNotNull(estoques);
            Assert.IsTrue(estoques.Count() > 0);
            Assert.False(estoques.First().IdEstoque == 0);
        }

        [Test]
        public async Task GetEstoqueById_ReturnSuccess()
        {
            var idEstoque = 2;
            var estoqueExiste = await _estoqueRepository.GetEstoqueById(idEstoque);
            Assert.IsNotNull(estoqueExiste);

            var estoqueNaoExiste = await _estoqueRepository.GetEstoqueById(100);
            Assert.IsNull(estoqueNaoExiste);

        }

        [Test]
        public async Task GetEstoqueByProductId_ReturnsOneEstoque()
        {
            var idProduto = 2;
            var estoqueExiste = await _estoqueRepository.GetEstoqueByProductId(idProduto);
            Assert.IsNotNull(estoqueExiste);
            Assert.That(estoqueExiste.IdProduto, Is.EqualTo(idProduto));
        }

        [Test]
        public async Task UpdatingExistingEstoque_SuccessUpdating()
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
        public async Task DeleteEstoque_ReturnTrue()
        {
            var idEstoque = 1;
            var estoqueExistente = await _estoqueRepository.GetEstoqueById(idEstoque);
            var estoqueParaDeletar = new Estoque(estoqueExistente.IdEstoque, estoqueExistente.Quantidade, estoqueExistente.IdProduto);
            
            var deletado = await _estoqueRepository.Delete(estoqueParaDeletar);
            Assert.IsTrue(deletado);
            
            var conferindoDelecao = await _estoqueRepository.GetEstoqueById(idEstoque);
            Assert.IsNull(conferindoDelecao);

        }

        private void CreateEstoque()
        {
            List<Produto> produtos = DataSourceProduto(_produtoRepository).Result;

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
                _estoqueRepository.CreateOrUpdate(item).Wait();
            }
        }
    }
}
