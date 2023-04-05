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
    public class CategoriaRepositoryTest : SetupSqlLite
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaRepositoryTest()
        {
            _categoriaRepository = new CategoriaRepository(_contextOptions);
            DataSourceCategoria(_categoriaRepository).Wait();
        }

        //[Test]
        //public async Task CreateCategory()
        //{
        //    var categorias = new List<Categoria>()
        //    {
        //        new Categoria(""),
        //        new Categoria("Carne Branca"),
        //        new Categoria("Hortaliças"),
        //        new Categoria("Tempero"),
        //        new Categoria("Limpeza"),
        //        new Categoria("Elétrica"),
        //        new Categoria("Frios"),
        //        new Categoria("Laticionio")
        //    };

        //    foreach (var categoria in categorias)
        //    {
        //        await _categoriaRepository.Insert<Categoria>(categoria);
        //        Assert.True(categoria.IdCategoria > 0);
        //    }
        //}

        [Test]
        public async Task UpdateCategory()
        {
            var idFromUser = 5;
            var caterogia = await _categoriaRepository.GetCategoryById(idFromUser);
            int idCategoria = caterogia.IdCategoria;
            caterogia.Nome = "Laticionios";

            var updated = await _categoriaRepository.Update(caterogia);

            Assert.True(updated);
            Assert.True(caterogia.IdCategoria == idCategoria);

            var caterogia2 = await _categoriaRepository.GetCategoryByName("Laticionios");
            Assert.NotNull(caterogia2);
            Assert.True(caterogia2.First().IdCategoria == idCategoria);
        }

        [Test]
        public async Task GetCategoryByName()
        {
            var caterogias = (await _categoriaRepository.GetCategoryByName("Car")).ToList();

            Assert.True(caterogias.Count() == 2);
        }

        [Test]
        public async Task GetAllCategories()
        {
            var caterogias = await _categoriaRepository.GetAllCategories();
            caterogias = caterogias.ToList();
            Assert.NotNull(caterogias);
            Assert.True(caterogias.Count() > 0);
        }

        [Test]
        public async Task GetCategoryById()
        {
            int expectId = 2;
            var caterogias = await _categoriaRepository.GetCategoryById(expectId);

            Assert.NotNull(caterogias);
            Assert.True(caterogias.IdCategoria == expectId);
        }

        [Test]
        public async Task DeleteCategory()
        {
            int idCategoria = 8;
            var caterogia = await _categoriaRepository.GetCategoryById(idCategoria);
            var deleted = await _categoriaRepository.Remove(caterogia);
            Assert.IsTrue(deleted);

            var categoriaV2 = await _categoriaRepository.GetCategoryById(idCategoria);
            Assert.IsNull(categoriaV2);
        }
    }
}
