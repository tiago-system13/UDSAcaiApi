using System;
using System.Collections.Generic;
using UDSAcaiApi.Dominio.Entidades.Base;

namespace UDSAcaiApi.Dominio.Entidades
{
    public class Adicionais: EntidadeBase
    {
        public string Descricao { get; set; }

        public decimal? Valor { get; set; }

        public TimeSpan? Tempo { get; set; }

        public List<ItensAdicionaisPedido> ItensAdicionais { get; set; }
    }
}
