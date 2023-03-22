using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Entities
{
    public class CategoriaProduto
    {
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
    }
}
