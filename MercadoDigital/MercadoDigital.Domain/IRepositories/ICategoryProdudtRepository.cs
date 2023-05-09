using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface ICategoryProdudtRepository
    {
        Task<bool> Create(CategoriaProduto categoryProduct);
    }
}
