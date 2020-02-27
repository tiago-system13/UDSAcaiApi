using System.ComponentModel.DataAnnotations;

namespace UDSAcaiApi.Models.Dto
{
    public class SaborDto
    {
        [Required(ErrorMessage = "O campo descrição é de preenchimento obrigatório")]
        public string Descricao { get; set; }
    }
}
