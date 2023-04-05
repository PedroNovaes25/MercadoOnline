using Castle.Components.DictionaryAdapter.Xml;
using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoOnlineTest
{
    public class CategoriaRepositoryTest : TestWithSqlLite
    {
        private readonly CategoriaRepository _categoriaRepositoryV2;

        public CategoriaRepositoryTest()
        {
            this._categoriaRepositoryV2 = new CategoriaRepository(_contextOptions);
            LoadDatas().Wait();
        }

        private async Task LoadDatas()
        {
            var categorias = new List<Categoria>()
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

            foreach (var categoria in categorias)
            {
                await _categoriaRepositoryV2.Insert<Categoria>(categoria);
            }
        }

        [Fact]
        public async Task CreateCategory()
        {
            var categorias = new List<Categoria>()
            {
                new Categoria("Massa"),
                new Categoria("Saudável")
            };

            foreach (var categoria in categorias)
            {
                var model = await _categoriaRepositoryV2.Insert<Categoria>(categoria);
                Assert.True(categoria.IdCategoria > 0);
            }
        }

        [Fact]
        public async Task UpdateCategory()
        {
            var caterogia = await _categoriaRepositoryV2.GetCategoryById(8);
            int idCategoria = caterogia.IdCategoria;
            caterogia.Nome = "Laticionios";

            var create = await _categoriaRepositoryV2.Update(caterogia);

            Assert.True(create);
            Assert.True(caterogia.IdCategoria == idCategoria);

            var caterogia2 = await _categoriaRepositoryV2.GetCategoryByName("Laticionios");
            Assert.NotNull(caterogia2);
            Assert.True(caterogia2.First().IdCategoria == idCategoria);
        }

        [Fact]
        public async Task GetCategoryByName()
        {
            var caterogias = (await _categoriaRepositoryV2.GetCategoryByName("Car")).ToList();

            foreach (var item in caterogias)
            {
                Assert.Contains("Carne", item.Nome);
            }
            Assert.True(caterogias.Count() == 2);
        }

        [Fact]
        public async Task GetAllCategories()
        {
            var caterogias = await _categoriaRepositoryV2.GetAllCategories();
            caterogias = caterogias.ToList();
            Assert.NotNull(caterogias);
            Assert.True(caterogias.Count() > 0);
        }

        [Fact]
        public async Task GetCategoryById()
        {
            int expectId = 2;
            var caterogias = await _categoriaRepositoryV2.GetCategoryById(expectId);
            
            Assert.NotNull(caterogias);
            Assert.True(caterogias.IdCategoria == expectId);
        }
    }
}
