using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UDSAcaiApi.Models.Dto
{
    public class PedidoDto
    {
        [Required(ErrorMessage = "O campo preparação é de preenchimento obrigatório")]
        public int? PreparacaoId { get; set; }

        public List<ItemAdicionalDto> ItensAdicionais { get; set; }
    }
}
