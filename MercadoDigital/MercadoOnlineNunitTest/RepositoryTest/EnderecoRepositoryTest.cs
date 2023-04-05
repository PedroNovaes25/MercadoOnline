using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoOnlineNunitTest.RepositoryTest
{
    internal class EnderecoRepositoryTest : SetupSqlLite
    {
        private readonly EndecoRepository _enderecoRepository;

        public EnderecoRepositoryTest()
        {
            _enderecoRepository = new EndecoRepository(_contextOptions);
            DataSourceEndereco(_enderecoRepository).Wait();
        }

        [Test]
        public async Task GetEnderecoById()
        {
            int expectId = 2;
            var endereco = await _enderecoRepository.GetEnderecoById(expectId);

            Assert.NotNull(endereco);
            Assert.True(endereco.IdEndereco == expectId);
        }

        [Test]
        public async Task UpdateEndereco()
        {
            int idResearch = 3;
            var endereco = await _enderecoRepository.GetEnderecoById(idResearch);
            int idEndereco = endereco.IdEndereco;
            endereco.UF = "SP";
            endereco.Cep = "08084808";
            endereco.Logradouro= "Rua Seis";

            var updated = await _enderecoRepository.Update(endereco);

            Assert.True(updated);
            Assert.True(endereco.IdEndereco == idEndereco);

            var verificandoEndereci = await _enderecoRepository.GetEnderecoById(idResearch);
            Assert.NotNull(verificandoEndereci);
            Assert.True(verificandoEndereci.Cep == endereco.Cep);
            Assert.True(verificandoEndereci.Logradouro == endereco.Logradouro);
        }

        [Test]
        public async Task DeleteEndereco()
        {
            int idEndereco = 4;
            var endereco = await _enderecoRepository.GetEnderecoById(idEndereco);
            var deleted = await _enderecoRepository.Remove(endereco);
            Assert.IsTrue(deleted);

            var enderecoVerificando = await _enderecoRepository.GetEnderecoById(idEndereco);
            Assert.IsNull(enderecoVerificando);
        }
    }
}
