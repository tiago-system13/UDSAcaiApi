using System;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Interfaces;
using UDSAcaiApi.Dominio.Servicos.Interfaces;

namespace UDSAcaiApi.Dominio.Servicos
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepositorio _repositorioPedido;
        private readonly IPreparacaoRepositorio _repositorioPreparacao;
        private readonly IAdicionaisRepositorio _repositorioAdicionais;

        public PedidoService(IPedidoRepositorio repositorioPedido, IPreparacaoRepositorio repositorioPreparacao,
            IAdicionaisRepositorio repositorioAdicionais)
        {
            _repositorioPedido = repositorioPedido;
            _repositorioPreparacao = repositorioPreparacao;
            _repositorioAdicionais = repositorioAdicionais;
        }

        public Pedido Incluir(Pedido pedido)
        {
            var possuiItensAdicionais = pedido.ItensAdicionais != null;

            if (possuiItensAdicionais)
            {
                foreach (var adicionais in pedido.ItensAdicionais)
                {
                    adicionais.Pedido = pedido;
                }
      
            }

            var preparacao = _repositorioPreparacao.ObterPorId(pedido.PreparacaoId);

            if (preparacao == null)
            {
                throw new ArgumentException("Pedido não encontrado!");
            }

            pedido.Total = possuiItensAdicionais ? CalcularTotalPedido(pedido, preparacao): preparacao.Valor;
            pedido.Data = DateTime.Now;

            return  ObterPorId(_repositorioPedido.Incluir(pedido).Id);
        }

        private decimal CalcularTotalPedido(Pedido pedido, Preparacao preparacao)
        {
            var valorPacial = preparacao.Valor;
          
                foreach (var itemAdicional in pedido.ItensAdicionais)
                {
                    var adicional = _repositorioAdicionais.ObterPorId(itemAdicional.AdicionalId);

                    valorPacial += (decimal)adicional?.Valor;
                }

            return valorPacial;
        }

        public Pedido ObterPorId(int id)
        {

            var pedido = _repositorioPedido.ObterPorId(id);

            if (pedido == null)
            {
                throw new ArgumentException("Pedido não encontrado!");
            }

            var possuiItensAdicionais = pedido.ItensAdicionais != null;

            pedido.Duracao = possuiItensAdicionais ? CalcularTempoFinalPedido(pedido): pedido.Duracao;

            return pedido;

        }

        private TimeSpan? CalcularTempoFinalPedido(Pedido pedido)
        {
            var duracaoParcial = (TimeSpan?)TimeSpan.Zero;

            foreach (var itemAdicional in pedido.ItensAdicionais)
            {
                duracaoParcial += itemAdicional?.Adicionais?.Tempo;
            }

            return duracaoParcial + pedido.Preparacao?.Tempo;
        }
    }
}
