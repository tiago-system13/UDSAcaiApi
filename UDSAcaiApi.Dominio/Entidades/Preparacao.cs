using System;
using System.Collections.Generic;
using UDSAcaiApi.Dominio.Entidades.Base;

namespace UDSAcaiApi.Dominio.Entidades
{
    public class Preparacao: EntidadeBase
    {
        public int SaborId { get; set; }
        public int TamanhoId { get; set; }
        public TimeSpan Tempo { get; set; }
        public decimal Valor { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public Sabor Sabor { get; set; }
        public Tamanho Tamanho { get; set; }
    }
}
