using System.Collections.Generic;
using UDSAcaiApi.Dominio.Entidades.Base;

namespace UDSAcaiApi.Dominio.Entidades
{
    public class Sabor: EntidadeBase
    {
        public string Descricao { get; set; }

        public List<Preparacao> Preparacoes { get; set; }
    }
}
