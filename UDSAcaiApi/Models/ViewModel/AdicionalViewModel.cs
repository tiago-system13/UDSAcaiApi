using System;

namespace UDSAcaiApi.Models.ViewModel
{
    public class AdicionalViewModel
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal? Valor { get; set; }

        public TimeSpan? Tempo { get; set; }
    }
}
