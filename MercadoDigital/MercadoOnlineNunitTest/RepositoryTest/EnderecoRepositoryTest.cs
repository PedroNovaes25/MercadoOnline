using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MercadoOnlineNunitTest.RepositoryTest
{
    internal class EnderecoRepositoryTest : SetupSqlLite
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IUsuarioRepository _userRepository;

        public EnderecoRepositoryTest()
        {
            _enderecoRepository = new EnderecoRepository(_contextOptions);
            _userRepository = new UsuarioRepository(_contextOptions);
            CreateEnderecos();
        }

        [Test]
        public async Task GetAddressById_ReturnsOneAddress()
        {
            int expectId = 2;
            var address = await _enderecoRepository.GetEnderecoById(expectId);

            Assert.NotNull(address);
            Assert.True(address.IdEndereco == expectId);
        }

        [Test]
        public async Task UpdatingExistingAddress_SuccessUpdating()
        {
            int idResearch = 3;
            var address = await _enderecoRepository.GetEnderecoById(idResearch);
            int idEndereco = address.IdEndereco;
            address.UF = "SP";
            address.Cep = "08084808";
            address.Logradouro= "Rua Seis";

            var updated = await _enderecoRepository.Update(address);

            Assert.True(updated);
            Assert.True(address.IdEndereco == idEndereco);

            var filteredAddress = await _enderecoRepository.GetEnderecoById(idResearch);
            Assert.NotNull(filteredAddress);
            Assert.True(filteredAddress.Cep == address.Cep);
            Assert.True(filteredAddress.Logradouro == address.Logradouro);
        }

        [Test]
        public async Task DeleteAddress_ReturnTrue()
        {
            int idEndereco = 4;
            var address = await _enderecoRepository.GetEnderecoById(idEndereco);
            var deleted = await _enderecoRepository.Delete(address);
            Assert.IsTrue(deleted);

            var filteredAddress = await _enderecoRepository.GetEnderecoById(idEndereco);
            Assert.IsNull(filteredAddress);
        }

        #region Test Data Source

        private void CreateEnderecos() 
        {
            var users = CreateUsers(_userRepository).Result;

            var addresses = new List<Endereco>()
            {
                new Endereco("12345678", "Rua 1", 15, "Bairro A", "Cidade A", "TO", users[0].IdUsuario),
                new Endereco("87654321", "Rua 2", 14, "Bairro B", "Cidade B", "MS", users[1].IdUsuario),
                new Endereco("123654789", "Rua 3", 16, "Bairro C", "Cidade C", "MT", users[2].IdUsuario),
                new Endereco("987456123", "Rua 4", 16, "Bairro D", "Cidade D", "MG", users[3].IdUsuario),
            };
            
            foreach (var address in addresses) 
            {
                DataSourceEndereco(_enderecoRepository, address).Wait();
            }
        }
        #endregion

    }
}
