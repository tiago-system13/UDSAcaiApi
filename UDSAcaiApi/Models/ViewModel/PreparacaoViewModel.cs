using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UDSAcaiApi.Models.ViewModel
{
    public class PreparacaoViewModel
    {
        public int Id { get; set; }
        public TimeSpan Tempo { get; set; }
        public decimal Valor { get; set; }
        public SaborViewModel Sabor { get; set; }
        public TamanhoViewModel Tamanho { get; set; }
    }
}
