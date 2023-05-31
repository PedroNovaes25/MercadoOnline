﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.input.Login
{
    public class UserInputDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string RG { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }

}
