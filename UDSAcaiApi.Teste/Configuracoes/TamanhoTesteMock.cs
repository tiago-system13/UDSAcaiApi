using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Teste.Configuracoes
{
   public static class TamanhoTesteMock
    {
        public static List<Tamanho> ObterTamanhoMock()
        {
            return new List<Tamanho>()
            {
                new Tamanho()
                {
                    Id = 1,
                    Descricao = "Pequeno (300 ml)"
                },
                 new Tamanho()
                {
                    Id = 2,
                    Descricao = "Médio (500 ml)"
                },
                  new Tamanho()
                {
                    Id = 3,
                    Descricao = "Grande (700 ml)"
                }
            };
        }
    }
}
