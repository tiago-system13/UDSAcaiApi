using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Interfaces;
using UDSAcaiApi.Dominio.Servicos;
using UDSAcaiApi.Teste.Configuracoes;

namespace UDSAcaiApi.Teste.Servico
{
    public class PedidoServiceTeste
    {
        private Mock<PedidoService> pedidoServiceMock;

        private Mock<IPedidoRepositorio> pedidoRepositorioMock;

        private Mock<IPreparacaoRepositorio> preparacaoRepositorioMock;

        private Mock<IAdicionaisRepositorio> adicionaisRepositorioMock;

        [SetUp]
        public void Setup()
        {
            pedidoRepositorioMock = new Mock<IPedidoRepositorio>();
            preparacaoRepositorioMock = new Mock<IPreparacaoRepositorio>();
            adicionaisRepositorioMock = new Mock<IAdicionaisRepositorio>();

            var pedidoMock = PedidoTesteMock.ObterPedidoComItensAdicionaisMock();

            preparacaoRepositorioMock.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(pedidoMock.Preparacao);
            adicionaisRepositorioMock.Setup(a => a.ObterPorId(It.IsAny<int>())).Returns(pedidoMock.ItensAdicionais.First().Adicionais);

            pedidoRepositorioMock.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(pedidoMock);
            pedidoRepositorioMock.Setup(s => s.Incluir(It.IsAny<Pedido>())).Returns(pedidoMock);

            pedidoServiceMock = new Mock<PedidoService>(pedidoRepositorioMock.Object,preparacaoRepositorioMock.Object,adicionaisRepositorioMock.Object);
        }

        [Test]
        public void ObterPedidoPorIdComSucesso()
        {
            var pedidoDbMock = PedidoTesteMock.ObterPedidoComItensAdicionaisMock();
            var PedidoResultado = pedidoServiceMock.Object.ObterPorId(It.IsAny<int>());

            Assert.NotNull(PedidoResultado);
            Assert.AreEqual(pedidoDbMock.PreparacaoId, pedidoDbMock.PreparacaoId);
            Assert.AreEqual(pedidoDbMock.Total, pedidoDbMock.Total);
            Assert.AreEqual(pedidoDbMock.Duracao, pedidoDbMock.Duracao);
        }

        [Test]
        public void IncluirPedidoComAdicionaisEAcrescimoDeTempoSucesso()
        {
            var pedidoDbMock = PedidoTesteMock.ObterPedidoComItensAdicionaisMock();
            pedidoDbMock.Duracao = TimeSpan.Parse("00:15:00");
            pedidoDbMock.Total = 13;
            pedidoRepositorioMock.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(pedidoDbMock);            
            pedidoRepositorioMock.Setup(s => s.Incluir(It.IsAny<Pedido>())).Returns(pedidoDbMock);

            var pedidoResultado = pedidoServiceMock.Object.Incluir(PedidoTesteMock.ObterPedidoComItensAdicionaisMock());

            Assert.NotNull(pedidoResultado);
            Assert.IsNotEmpty(pedidoResultado.ItensAdicionais);
            Assert.AreEqual(pedidoResultado.PreparacaoId, pedidoDbMock.PreparacaoId);
            Assert.AreEqual(pedidoResultado.Total, pedidoDbMock.Total);
            Assert.AreEqual(pedidoResultado.Duracao, pedidoDbMock.Duracao);

        }

        [Test]
        public void IncluirPedidoComAdicionaisSucesso()
        {
            var pedidoDbMock = PedidoTesteMock.ObterPedidoComItensAdicionaisMock();

            var pedidoResultado = pedidoServiceMock.Object.Incluir(PedidoTesteMock.ObterPedidoComItensAdicionaisMock());

            Assert.NotNull(pedidoResultado);
            Assert.IsNotEmpty(pedidoResultado.ItensAdicionais);
            Assert.AreEqual(pedidoResultado.PreparacaoId, pedidoDbMock.PreparacaoId);
            Assert.AreEqual(pedidoResultado.Total, pedidoDbMock.Total);
            Assert.AreEqual(pedidoResultado.Duracao, pedidoDbMock.Duracao);
        }

        [Test]
        public void IncluirPedidoSemAdicionaisSucesso()
        {
            var pedidoDbMock = PedidoTesteMock.ObterPedidoSemItensAdicionaisMock();

            pedidoRepositorioMock.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(pedidoDbMock);
            pedidoRepositorioMock.Setup(s => s.Incluir(It.IsAny<Pedido>())).Returns(pedidoDbMock);

            var pedidoResultado = pedidoServiceMock.Object.Incluir(PedidoTesteMock.ObterPedidoSemItensAdicionaisMock());

            Assert.NotNull(pedidoResultado);
            Assert.IsNull(pedidoResultado.ItensAdicionais);
            Assert.AreEqual(pedidoResultado.PreparacaoId, pedidoDbMock.PreparacaoId);
            Assert.AreEqual(pedidoResultado.Total, pedidoDbMock.Total);
            Assert.AreEqual(pedidoResultado.Duracao, pedidoDbMock.Duracao);
        }

        [Test]
        public void IncluirPedidoComExceptionPedidoNaoEncontrado()
        {
            var pedidoDbMock = PedidoTesteMock.ObterPedidoSemItensAdicionaisMock();

            preparacaoRepositorioMock.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns((Preparacao) null);

            pedidoRepositorioMock.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(pedidoDbMock);
            pedidoRepositorioMock.Setup(s => s.Incluir(It.IsAny<Pedido>())).Returns(pedidoDbMock);

            var pedido = PedidoTesteMock.ObterPedidoSemItensAdicionaisMock();
            pedido.PreparacaoId = 5;

            var ex = Assert.Throws<ArgumentException>(() => pedidoServiceMock.Object.Incluir(pedido));

            Assert.That(ex.Message, Is.EqualTo("Pedido não encontrado!"));
            
        }
    
    }
}
