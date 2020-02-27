using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Teste.Configuracoes
{
    public static class PreparacaoTesteMock
    {
        public static Preparacao ObterPreparacaoPorSaborTamanhoMock()
        {
            return
                new Preparacao()
                {
                    Id = 1,
                    SaborId = 1,
                    TamanhoId = 3,
                    Tempo = TimeSpan.Parse("00:10:00"),
                    Valor = 10  
                };
        }

        public static Preparacao ObterPreparacaoKiwiPorSaborTamanhoMock()
        {
            return
                new Preparacao()
                {
                    Id = 1,
                    SaborId = 3,
                    TamanhoId = 3,
                    Tempo = TimeSpan.Parse("00:10:00"),
                    Valor = 15
                };
        }
    }
}
