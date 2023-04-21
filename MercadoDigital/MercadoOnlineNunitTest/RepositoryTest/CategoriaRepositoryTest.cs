using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoOnlineNunitTest.RepositoryTest
{
    public class CategoriaRepositoryTest : SetupSqlLite
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaRepositoryTest()
        {
            _categoriaRepository = new CategoriaRepository(new GeneralRepository(Context));
            DataSourceCategoria(_categoriaRepository).Wait();
        }

        [Test]
        public async Task UpdatingExistingCategory_SuccessUpdating()
        {
            var idFromUser = 1;
            var category = await _categoriaRepository.GetCategoryById(idFromUser);
            int idCategory = category.IdCategoria;
            category.Nome = "Laticionios";

            var updatedCategory = await _categoriaRepository.Update(category);

            Assert.True(updatedCategory);
            Assert.True(category.IdCategoria == idCategory);

            var filteredCategory = await _categoriaRepository.GetCategoryByName("Laticionios");
            Assert.NotNull(filteredCategory);
            Assert.True(filteredCategory.First().IdCategoria == idCategory);
        }

        [Test]
        public async Task GettingCategoryThatContainsCharacters_ReturnSuccess()
        {
            var categories = (await _categoriaRepository.GetCategoryByName("Car")).ToList();

            Assert.IsNotNull(categories);
            Assert.True(categories.Count() > 0);
            var categoriesNames = categories.Select(c => c.Nome).ToList();
            categoriesNames.ForEach(c => Assert.True(c.Contains("Car")));
        }

        [Test]
        public async Task ReturnAllExistingCategories_ReturnSuccess()
        {
            var categories = await _categoriaRepository.GetAllCategories();
            categories = categories.ToList();
            Assert.NotNull(categories);
            Assert.True(categories.Count() > 0);
        }

        [Test]
        public async Task GetCategoryById_ReturnsOneCategory()
        {
            int expectId = 2;
            var category = await _categoriaRepository.GetCategoryById(expectId);

            Assert.NotNull(category);
            Assert.True(category.IdCategoria == expectId);
        }

        [Test]
        public async Task DeleteCategory_ReturnTrue()
        {
            int idCategoria = 3;
            var category = await _categoriaRepository.GetCategoryById(idCategoria);
            var deleted = await _categoriaRepository.Delete(category);
            Assert.IsTrue(deleted);

            var filteredCategory = await _categoriaRepository.GetCategoryById(idCategoria);
            Assert.IsNull(filteredCategory);
        }
 
    }
}
