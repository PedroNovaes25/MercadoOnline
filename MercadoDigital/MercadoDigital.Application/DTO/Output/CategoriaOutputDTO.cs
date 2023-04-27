using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Output
{
    public class CategoriaOutputDTO
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
    }
}
