using Moq;
using NUnit.Framework;
using UDSAcaiApi.Dominio.Interfaces;
using UDSAcaiApi.Dominio.Servicos;
using UDSAcaiApi.Teste.Configuracoes;

namespace UDSAcaiApi.Teste.Servico
{
    public class SaborServiceTeste
    {
        private Mock<SaborService> saborService;

        [SetUp]
        public void Setup()
        {
            var saborRepositorioMock = new Mock<ISaborRepositorio>();
            saborRepositorioMock.Setup(s => s.ObterTodos()).Returns(SaborTesteMock.ObterSaborMock);
            saborService = new Mock<SaborService>(saborRepositorioMock.Object);
        }

        [Test]
        public void ObterTodosSaboresComSucesso()
        {
            int quantidadeSaborDbMock = SaborTesteMock.ObterSaborMock().Count;
            int quanteSaborResultado = saborService.Object.ObterTodos().Count;

            Assert.AreEqual(quantidadeSaborDbMock, quanteSaborResultado);
        }
    }
}
