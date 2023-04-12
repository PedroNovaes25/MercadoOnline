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
    internal class CategoriaProdutoTest : SetupSqlLite
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaProdutoTest()
        {
            _categoriaProdutoRepository = new CategoriaProdutoRepository(_contextOptions);
            _produtoRepository = new ProdutoRepository(_contextOptions);
            _categoriaRepository = new CategoriaRepository(_contextOptions);

            CreateCategoriaPedido();
        }

        [Test]
        public async Task GettingPedidos_CheckingLinkedOrderItems_LinkedSuccess()
        {
            var categoryId = 6;
            var productsByIdCategory = (await _produtoRepository.GetAllProductsFromCategoryId(categoryId)).ToList();

            Assert.IsNotNull(productsByIdCategory);
            Assert.IsTrue(productsByIdCategory.Count > 1);

            foreach (var item in productsByIdCategory)
            {
                Assert.That(item.CategoriaProduto.First().IdCategoria, Is.EqualTo(categoryId));
            }
        }

        #region
        private void CreateCategoriaPedido() 
        {
            var categorias = DataSourceCategoria(_categoriaRepository).Result;
            var produtos = DataSourceProduto(_produtoRepository).Result;


            for (int i = 0; i < produtos.Count; i++) 
            {
                var categoria = (i+2) >= produtos.Count ? categorias.Last() : categorias[categorias.Count - 2];
                DataSourceCategoriaProduto(_categoriaProdutoRepository, categoria, produtos[i]).Wait();
            }
        }
        #endregion
    }
}
