using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Entities
{
    public class CategoriaProduto
    {
        public int IdProduto { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public Produto Produto { get; set; }
    }
}
