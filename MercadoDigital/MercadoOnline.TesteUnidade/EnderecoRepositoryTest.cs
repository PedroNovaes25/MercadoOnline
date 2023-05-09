using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Connection;
using MercadoDigital.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Identity.Client;
using Moq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Xml;

namespace MercadoOnline.TesteUnidade
{
    public class EnderecoRepositoryTest
    {
        private readonly Mock<IAddressRepository> _mockEnderecoRepo;


        public EnderecoRepositoryTest()
        {
            _mockEnderecoRepo = new Mock<IAddressRepository>();
        }

        [Fact]
        public async Task DeleteEnderecoBy_ExistingEndereco_ReturnTrue()
        {
            //Arrange
            var idEndereco = 2;
            var endereco = new Endereco("0808080", "Rua 1", "5", "Bairro 1", "Cidade 1", "UF", 5);
            endereco.IdEndereco = idEndereco;
            _mockEnderecoRepo.Setup(e => e.Delete(It.IsAny<Endereco>())).ReturnsAsync(true);

            //Act
            var enderecoCreated = await _mockEnderecoRepo.Object.Delete(endereco);
            //Assert
            Assert.True(enderecoCreated);
            
        }

        [Fact]
        public async Task DeleteEnderecoBy_NonExistingEndereco_ReturnTrue()
        {
            //Arrange
            var idEndereco = 2;
            var endereco = new Endereco("0808080", "Rua 1", "5", "Bairro 1", "Cidade 1", "UF", 5);
            endereco.IdEndereco = idEndereco;
            _mockEnderecoRepo.Setup(e => e.Delete(It.IsAny<Endereco>())).ReturnsAsync(false);

            //Act
            var enderecoCreated = await _mockEnderecoRepo.Object.Delete(endereco);

            //Assert
            Assert.False(enderecoCreated);
        }

        [Fact]
        public async Task GetEnderecoById_ExistingEndereco_ReturnEndereco() 
        {
            //Arrange
            int idEndereco = 5;
            int idUsuario = 6;

            var endereco = new Endereco("0808080", "Rua 1", "5", "Bairro 1", "Cidade 1", "UF", idUsuario);
            endereco.IdEndereco = idEndereco;
             _mockEnderecoRepo.Setup(x => x.GetAddressById(It.IsAny<int>())).ReturnsAsync(endereco);
            
            //Act
            var enderecoById = await _mockEnderecoRepo.Object.GetAddressById(idEndereco);

            //Assert
            Assert.NotNull(_mockEnderecoRepo.Object);
            Assert.Equal(idUsuario, enderecoById.IdUsuario);
            Assert.Equal(idEndereco, enderecoById.IdEndereco);
        }

        [Fact]
        public async Task GetEnderecoById_NonExistingEndereco_ReturnNull()
        {
            //Arrange
            var idAny = 10;
            //Act
            _mockEnderecoRepo.Setup(x => x.GetAddressById(It.IsAny<int>())).ReturnsAsync(() => null);

            var enderecoById = await _mockEnderecoRepo.Object.GetAddressById(idAny);
            //Assert
            Assert.Null(enderecoById);
        }

        [Fact]
        public async Task UpdateEndereco_ExistingEndereco_returnTrue()
        {
            //Arrange
            var idEndereco = 2;
            var endereco = new Endereco("0808080", "Rua 1", "5", "Bairro 1", "Cidade 1", "UF", 5);
            endereco.IdEndereco = idEndereco;
            _mockEnderecoRepo.Setup(e => e.Update(It.IsAny<Endereco>())).ReturnsAsync(true);

            //Act
            var enderecoCreated = await _mockEnderecoRepo.Object.Update(endereco);
            //Assert
            Assert.True(enderecoCreated);
        }



        #region Testando dbcontext

        [Fact]
        public async Task Create_Endereco_ReturnTrue()
        {
            //Arrange
            //Configurar DbContext e simulação de DbSet 
            var dbsetEnderecoMock = new Mock<DbSet<Endereco>>();

            var dbContextMock = new Mock<MercadoDbContext>();
            dbContextMock.Setup(db => db.Enderecos).Returns(dbsetEnderecoMock.Object);

            var endereco = new Endereco("0808080", "Rua 1", "5", "Bairro 1", "Cidade 1", "UF", 5);
            //endereco.IdEndereco = 2;

            //Act
            var geralRepository = new GeneralRepository(dbContextMock.Object);
            var enderecoRepository = new EnderecoRepository(geralRepository);
            var enderecoCreated = await enderecoRepository.Create(endereco);

            //Assert
            dbsetEnderecoMock.Verify(m => m.Add(It.IsAny<Endereco>()), Times.Once());
            dbContextMock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.True(enderecoCreated);
        }


        #endregion
    }
}