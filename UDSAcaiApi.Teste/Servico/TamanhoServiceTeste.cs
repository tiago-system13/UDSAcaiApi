using Moq;
using NUnit.Framework;
using UDSAcaiApi.Dominio.Interfaces;
using UDSAcaiApi.Dominio.Servicos;
using UDSAcaiApi.Teste.Configuracoes;

namespace UDSAcaiApi.Teste.Servico
{
    public class TamanhoServiceTeste
    {
        private Mock<TamanhoService> tamanhoService;

        [SetUp]
        public void Setup()
        {
            var tamanhoRepositorioMock = new Mock<ITamanhoRepositorio>();
            tamanhoRepositorioMock.Setup(s => s.ObterTodos()).Returns(TamanhoTesteMock.ObterTamanhoMock);
            tamanhoService = new Mock<TamanhoService>(tamanhoRepositorioMock.Object);
        }

        [Test]
        public void ObterTodosTamanhosComSucesso()
        {
            int quantidadetamanhoDbMock = TamanhoTesteMock.ObterTamanhoMock().Count;
            int quantetamanhoResultado = tamanhoService.Object.ObterTodos().Count;

            Assert.AreEqual(quantidadetamanhoDbMock, quantetamanhoResultado);
        }
    }
}
