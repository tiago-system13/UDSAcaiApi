using Microsoft.EntityFrameworkCore;
using System.Linq;
using UDSAcaiApi.Dados.Contexto;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Interfaces;

namespace UDSAcaiApi.Dados.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly IRepositorioBase<Pedido> _repositorioPedido;
        private readonly UDSAcaiApiContext _contexto;

        public PedidoRepositorio(UDSAcaiApiContext contexto, IRepositorioBase<Pedido> repositorioPedido)
        {
            _contexto = contexto;
            _repositorioPedido = repositorioPedido;
        }
        public Pedido Incluir(Pedido pedido)
        {
           return _repositorioPedido.Incluir(pedido);
        }

        public Pedido ObterPorId(int id)
        {
            return _contexto.Pedidos.Include(p => p.Preparacao)
                                     .ThenInclude(p=>p.Sabor)
                                     .Include(p => p.Preparacao).ThenInclude(p=> p.Tamanho)
                                     .Include(p => p.ItensAdicionais).ThenInclude(a => a.Adicionais)
                                     .FirstOrDefault(p => p.Id == id);
        }
    }
}
