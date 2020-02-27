using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dominio.Servicos.Interfaces
{
    public interface IPedidoService
    {
        Pedido Incluir(Pedido pedido);

        Pedido ObterPorId(int id);
    }
}
