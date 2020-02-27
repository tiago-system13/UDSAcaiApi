using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UDSAcaiApi.Models.ViewModel
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public PreparacaoViewModel Preparacao { get; set; }

        public decimal Total { get; set; }

        public DateTime Data { get; set; }

        public TimeSpan? Duracao { get; set; }

        public List<ItemAdicionalViewModel> ItensAdicionais { get; set; }
    }
}
