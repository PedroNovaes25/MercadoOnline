using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Connection;
using MercadoDigital.Infra.Data.Migrations;
using MercadoDigital.Infra.Data.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MercadoOnlineTest
{
    public class TestWithSqlLite
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;
        public readonly DbContextOptions<MercadoDbContext> _contextOptions;
        public MercadoDbContext Context;

        public TestWithSqlLite()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();

            _contextOptions = new DbContextOptionsBuilder<MercadoDbContext>()
                .UseSqlite(_connection)
                .Options;

            Context = new MercadoDbContext(_contextOptions);
            Context.Database.EnsureCreated();
        }
    }
}