using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Teste.Configuracoes
{
    public static class SaborTesteMock
    {
        public static List<Sabor> ObterSaborMock()
        {
            return new List<Sabor>()
            {
                new Sabor()
                {
                    Id = 1,
                    Descricao = "Morango"
                },
                 new Sabor()
                {
                    Id = 2,
                    Descricao = "Banana"
                },
                  new Sabor()
                {
                    Id = 3,
                    Descricao = "Kiwi"
                }
            };
        }
    }
}
