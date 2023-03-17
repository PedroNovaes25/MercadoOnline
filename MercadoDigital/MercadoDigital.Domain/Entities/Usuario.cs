using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Entities
{
    public class Usuario
    {
        public Usuario(string nome, string rG, string cPF, DateOnly nascimento, int idade, string sexo, string celular, string email, string password)
        {
            Nome = nome;
            RG = rG;
            CPF = cPF;
            Nascimento = nascimento;
            Idade = idade;
            Sexo = sexo;
            Celular = celular;
            Email = email;
            Password = password;
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateOnly Nascimento { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
    }
}
