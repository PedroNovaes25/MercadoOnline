using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Input
{
    //Nota - DTO´s inputs servem para Insert e Update
    //Dto´s input só depende de input ou dto´s "glogal"
    public class CategoryInputDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "O {0} deve conter entre 4 a 40 caracteres.")]
        public string Nome { get; set; }
    }


    //Create(objeto)
    //Update(objeto + Parametro Input ID)

    //Get(Retorna infos + Id) 

    //Delete(Parametro Input ID)
}
