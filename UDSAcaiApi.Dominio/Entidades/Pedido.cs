using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UDSAcaiApi.Dominio.Entidades.Base;

namespace UDSAcaiApi.Dominio.Entidades
{
    public  class Pedido: EntidadeBase
    {
        public int PreparacaoId { get; set; }

        public decimal Total { get; set; }

        public DateTime Data { get; set; }

        [NotMapped]
        public TimeSpan? Duracao { get; set; }

        public Preparacao Preparacao { get; set; }

        public List<ItensAdicionaisPedido> ItensAdicionais { get; set; }

    }
}
