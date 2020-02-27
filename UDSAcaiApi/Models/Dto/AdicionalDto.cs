using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UDSAcaiApi.Models.Dto
{
    public class AdicionalDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Descrição é campo obrigatório")]
        public string Descricao { get; set; }

        public decimal? Valor { get; set; }

        public TimeSpan? Tempo { get; set; }
    }
}
