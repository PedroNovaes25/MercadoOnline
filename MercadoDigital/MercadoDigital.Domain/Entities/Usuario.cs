﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Entities
{
    public class Usuario
    {
        public Usuario(string nome, string rg, string cpf, DateTime nascimento, int idade, string sexo, string celular, string email, string password)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Nascimento = nascimento;
            Idade = idade;
            Sexo = sexo;
            Celular = celular;
            Email = email;
            Password = password;
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Endereco Endereco { get; set; }
        public Pedido Pedido { get; set; }
    }
}