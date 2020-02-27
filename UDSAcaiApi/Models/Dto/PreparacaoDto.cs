using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UDSAcaiApi.Models.Dto
{
    public class PreparacaoDto
    {
        [Required(ErrorMessage = "O campo sabor é de preenchimento obrigatório")]
        public int? SaborId { get; set; }

        [Required(ErrorMessage = "O campo tamanho é de preenchimento obrigatório")]
        public int? TamanhoId { get; set; }

        [Required(ErrorMessage = "O campo tempo é de preenchimento obrigatório")]
        public TimeSpan? Tempo { get; set; }

        [Required(ErrorMessage = "O campo valor é de preenchimento obrigatório")]
        public decimal? Valor { get; set; }
    }
}
