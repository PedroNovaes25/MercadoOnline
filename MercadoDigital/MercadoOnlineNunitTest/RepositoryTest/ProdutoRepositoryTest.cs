using MercadoDigital.Domain.Entities;
using MercadoDigital.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoOnlineNunitTest.RepositoryTest
{
    internal class ProdutoRepositoryTest : SetupSqlLite
    {

        private readonly ProdutoRepository produtoRepository;

        public ProdutoRepositoryTest()
        {
            produtoRepository = new ProdutoRepository(_contextOptions);
            DataSourceProduto(produtoRepository).Wait();
        }

        [Test]
        public async Task GetProdutoById_ReturnSuccess()
        {
            int idProduto = 2;
            var produto = await produtoRepository.GetProductById(idProduto);

            Assert.IsNotNull(produto);
        }


        [Test]
        public async Task GetProductByName_ReturnSuccess()
        {
            var produtos = (await produtoRepository.GetProductByName("F")).ToList();
            Assert.IsNotNull(produtos);
            Assert.That(produtos.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetAllExistingProducts_ReturnSuccess()
        {
            var produtos = (await produtoRepository.GetAllProducts()).ToList();
            Assert.IsNotNull(produtos);
            Assert.IsTrue(produtos.Count > 0);
        }

        [Test]
        public async Task Update_Success()
        {
            int idProduto = 2;
            var produto = await produtoRepository.GetProductById(idProduto);
            Assert.IsNotNull(produto);

            double novoPreco = 12.20;
            produto.Preco = novoPreco;

            await produtoRepository.Update(produto);
            Assert.That(produto.Preco, Is.EqualTo(novoPreco)); 
        }

        [Test]
        public async Task DeleteById_ProductExiting_Sucess()
        {
            int idProduto = 3;
            var produto = await produtoRepository.GetProductById(idProduto);
            Assert.IsNotNull(produto);

            var deleted = await produtoRepository.Delete(produto);
            Assert.IsTrue(deleted);
        }
    }
}
