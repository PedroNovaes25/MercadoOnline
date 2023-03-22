﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Entities
{
    public class Endereco
    {
        public Endereco(string cep, string logradouro, int numero, string bairro, string cidade, string uF)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
        }

        public int IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string? Complemento { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}