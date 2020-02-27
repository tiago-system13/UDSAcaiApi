using UDSAcaiApi.Dominio.Entidades.Base;

namespace UDSAcaiApi.Dominio.Entidades
{
    public class ItensAdicionaisPedido: EntidadeBase
    {
        public int PedidioId { get; set; }

        public Pedido Pedido { get; set; }

        public int AdicionalId { get; set; }

        public Adicionais Adicionais { get; set; }

    }
}
