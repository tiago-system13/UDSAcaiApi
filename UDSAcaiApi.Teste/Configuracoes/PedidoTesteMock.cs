using System;
using System.Collections.Generic;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Teste.Configuracoes
{
    public static class PedidoTesteMock
    {
        private static Pedido CriandoPedido()
        {
            return new Pedido()
            {
                Id = 1,
                PreparacaoId = 1,
                Preparacao = new Preparacao()
                {
                    SaborId = 1,
                    TamanhoId = 3,
                    Valor = 10,
                    Tempo = TimeSpan.Parse("00:10:00"),
                    Sabor = new Sabor()
                    {
                        Id = 1,
                        Descricao = "Morango"
                    },
                    Tamanho = new Tamanho()
                    {
                        Id = 3,
                        Descricao = "Grande (700 ml)"
                    }
                },
                Total = 16,
                Duracao = TimeSpan.Parse("00:15:00"),
            };
        }

        private static List<ItensAdicionaisPedido>  CriandoItensAdicionais()
        {
            return new List<ItensAdicionaisPedido>()
                    {
                        new ItensAdicionaisPedido()
                        {
                            PedidioId = 1,
                            AdicionalId = 1,
                            Adicionais = new Adicionais()
                            {
                                Id = 1,
                                Descricao = "Paçoca",
                                Tempo = TimeSpan.Parse("00:05:00"),
                                Valor = 3
                            }
                        }
                    };
        }

        public static Pedido ObterPedidoComItensAdicionaisMock()
        {
            var pedido = CriandoPedido();
            pedido.ItensAdicionais = CriandoItensAdicionais();
            return pedido;
        }

        public static Pedido ObterPedidoSemItensAdicionaisMock()
        {
            return CriandoPedido();
        }


    }
}
