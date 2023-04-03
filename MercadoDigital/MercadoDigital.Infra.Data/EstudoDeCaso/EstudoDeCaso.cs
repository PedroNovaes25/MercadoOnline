using MercadoDigital.Infra.Data.Connection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Infra.Data.EstudoDeCaso
{
    internal class Testes
    {

        public void Teste()
        {
        }
    }

    public interface IA
    {
        int RetornaInt();
    }

    public interface IB
    {
        int RetornaString();
    }


    public abstract class RepostoryHandler<T>
    {

        public void Insert(T value)
        {
            using (var context = ContextFactory.GetContext())
            {
                Insert(value, context);
            }
        }
        public abstract int Insert(T person, MercadoDbContext context);
        public void InsertOrUpdate(T value)
        {
            using (var context = ContextFactory.GetContext())
            {
                InsertOrUpdate(value, context);
            }
        }
        internal abstract void InsertOrUpdate(T person, MercadoDbContext context);

        private MercadoDbContext GetNewContext()
        {
            return new MercadoDbContext(new DbContextOptions<MercadoDbContext>()); //Apenas para teste
        }


    }
 

    public static class ContextFactory
    {
        private static MercadoDbContext _context;

        public static MercadoDbContext GetContext()
        {
            //return _context ?? (_context = new MercadoDbContext());
            throw new NotImplementedException();
        }
    }
}
