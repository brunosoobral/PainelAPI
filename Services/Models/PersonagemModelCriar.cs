using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class PersonagemModelCriar
    {
        [RegularExpression("^[A-Za-z0-9]{1,15}$", ErrorMessage = "Por favor, informe o Nickname.")]
        public string Nickname { get; set; }

        [RegularExpression("^[0-9]{1,1}$", ErrorMessage = "Por favor, informe a Classe.")]
        public int Classe { get; set; }
    }
}