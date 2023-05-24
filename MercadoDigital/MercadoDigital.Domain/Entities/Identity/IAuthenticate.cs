using MercadoDigital.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Entities.Identity
{
    public interface IAuthenticate
    {
        public object CreateToken(User user);
    }
}
