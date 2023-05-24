using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        //public IEnumerable<UserRole> UserRoles { get; set; }
        public Endereco Addresses { get; set; }
        public List<Pedido> Orders { get; set; }
    }
}
