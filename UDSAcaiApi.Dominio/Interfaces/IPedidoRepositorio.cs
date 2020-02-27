using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dominio.Interfaces
{
   public interface IPedidoRepositorio
    {
        Pedido Incluir(Pedido pedido);

        Pedido ObterPorId(int id);

    }
}
