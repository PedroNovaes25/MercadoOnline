using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoDigital.Domain.Entities.Identity;

namespace MercadoDigital.Domain.Entities
{
    public class Endereco
    {
        public Endereco(string cep, string logradouro, string numero, string bairro, string cidade, string uF, int userId)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
            UserId = userId;
        }

        public int IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string? Complemento { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
