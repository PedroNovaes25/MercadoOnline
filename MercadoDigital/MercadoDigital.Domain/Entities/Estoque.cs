using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Entities
{
    public class Estoque
    {
        public Estoque(int quantidade)
        {
            Quantidade = quantidade;
        }

        public int IdEstoque { get; set; }
        public int Quantidade { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
    }
}
