using Moq;
using NUnit.Framework;
using System;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Interfaces;
using UDSAcaiApi.Dominio.Servicos;
using UDSAcaiApi.Teste.Configuracoes;

namespace UDSAcaiApi.Teste.Servico
{
    public class PreparaAcaiServiceTeste
    {
        private Mock<PreparacaoService> preparacaoServiceMock;
        private Mock<IPreparacaoRepositorio> preparacaoRepositorioMock;

        [SetUp]
        public void Setup()
        {
            preparacaoRepositorioMock = new Mock<IPreparacaoRepositorio>();
            preparacaoRepositorioMock.Setup(s => s.ObterPorSaborTamanho(It.IsAny<int>(), It.IsAny<int>())).Returns(PreparacaoTesteMock.ObterPreparacaoPorSaborTamanhoMock());
            preparacaoRepositorioMock.Setup(s => s.Incluir(It.IsAny<Preparacao>())).Returns(PreparacaoTesteMock.ObterPreparacaoKiwiPorSaborTamanhoMock());
            preparacaoServiceMock = new Mock<PreparacaoService>(preparacaoRepositorioMock.Object);
        }

        [Test]
        public void ObterPreparacaoPorSaborTamanhoComSucesso()
        { 
            var preparacaoDbMock = PreparacaoTesteMock.ObterPreparacaoPorSaborTamanhoMock();
            var preparacaoResultado = preparacaoServiceMock.Object.ObterPorSaborTamanho(It.IsAny<int>(), It.IsAny<int>());

            Assert.NotNull(preparacaoResultado);
            Assert.AreEqual(preparacaoDbMock.SaborId, preparacaoDbMock.SaborId);
            Assert.AreEqual(preparacaoDbMock.TamanhoId, preparacaoDbMock.TamanhoId);
        }

        [Test]
        public void IncluirPreparacaoSaborKiwiComSucesso()
        {
            var preparacaoDbMock = PreparacaoTesteMock.ObterPreparacaoKiwiPorSaborTamanhoMock();
            preparacaoDbMock.Tempo += TimeSpan.Parse("00:05:00");

            preparacaoRepositorioMock.Setup(s => s.Incluir(It.IsAny<Preparacao>())).Returns(preparacaoDbMock);
            preparacaoRepositorioMock.Setup(s => s.ObterPorSaborTamanho(It.IsAny<int>(), It.IsAny<int>())).Returns((Preparacao)null);

            var preparacaoResultado = preparacaoServiceMock.Object.Incluir(PreparacaoTesteMock.ObterPreparacaoKiwiPorSaborTamanhoMock());

            Assert.NotNull(preparacaoResultado);
            Assert.AreEqual(preparacaoResultado.SaborId, preparacaoDbMock.SaborId);
            Assert.AreEqual(preparacaoResultado.TamanhoId, preparacaoDbMock.TamanhoId);
            Assert.AreEqual(preparacaoResultado.Tempo, preparacaoDbMock.Tempo);
        }

        [Test]
        public void IncluirPreparacaoSaborComSucesso()
        {
            var preparacaoDbMock = PreparacaoTesteMock.ObterPreparacaoPorSaborTamanhoMock();

            preparacaoRepositorioMock.Setup(s => s.Incluir(It.IsAny<Preparacao>())).Returns(preparacaoDbMock);

            preparacaoRepositorioMock.Setup(s => s.ObterPorSaborTamanho(It.IsAny<int>(), It.IsAny<int>())).Returns((Preparacao) null);

            var preparacaoResultado = preparacaoServiceMock.Object.Incluir(preparacaoDbMock);

            Assert.NotNull(preparacaoResultado);
            Assert.AreEqual(preparacaoResultado.SaborId, preparacaoDbMock.SaborId);
            Assert.AreEqual(preparacaoResultado.TamanhoId, preparacaoDbMock.TamanhoId);
            Assert.AreEqual(preparacaoResultado.Tempo, preparacaoDbMock.Tempo);
        }

        [Test]
        public void IncluirPreparacaoSaborExceptionPreparacaoExistente()
        {
            var preparacaoDbMock = PreparacaoTesteMock.ObterPreparacaoPorSaborTamanhoMock();

            preparacaoRepositorioMock.Setup(s => s.Incluir(It.IsAny<Preparacao>())).Returns(preparacaoDbMock);

            var ex = Assert.Throws<ArgumentException>(() => preparacaoServiceMock.Object.Incluir(preparacaoDbMock));

            Assert.That(ex.Message, Is.EqualTo("Já existe preparação cadastrada com o sabor e tamanho informado!"));

        }

    }
}
