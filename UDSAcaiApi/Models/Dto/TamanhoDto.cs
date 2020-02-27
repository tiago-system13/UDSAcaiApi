using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UDSAcaiApi.Models.Dto
{
    public class TamanhoDto
    {
        [Required(ErrorMessage = "O campo descrição é de preenchimento obrigatório")]
        public string Descricao { get; set; }
    }
}
