using System;
using System.Collections.Generic;

namespace UDSAcaiApi.Models.ViewModel
{
    public class HistoricoPedidoViewModel
    {
        public string Sabor { get; set; }

        public string Tamanho { get; set; }

        public decimal Preco  { get; set; }

        public List<AdicionalViewModel> Personalizacoes { get; set; }

        public Decimal ValorTotal { get; set; }

        public TimeSpan Duracao { get; set; }
    }
}
