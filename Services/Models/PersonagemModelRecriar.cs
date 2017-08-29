using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class PersonagemModelRecriar
    {
        [RegularExpression("^[A-Za-z0-9]{1,15}$", ErrorMessage = "Por favor, informe o Nickname.")]
        public string Nickname { get; set; }
    }
}