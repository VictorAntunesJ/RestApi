using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaisEventosVsCode.Models
{
    public class UsuarioTest
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Informe seu Nome")]
        public string nome { get; set; }

       [Required(ErrorMessage = "Informe seu E-mail")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um e-mail válido...")]
        public string email { get; set; }
        
       [Required(ErrorMessage = "Informe sua Senha")]
        [MinLength(8)]
        public string senha { get; set; }
    }
}