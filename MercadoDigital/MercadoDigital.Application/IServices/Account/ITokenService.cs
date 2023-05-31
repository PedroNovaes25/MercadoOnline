using MercadoDigital.Application.Account;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices.Account
{
    public interface ITokenService
    {
        AuthenticationResponseDTO CreateToken(UserOutputDTO userUpdateDto, List<string> userRoles);
    }
}
