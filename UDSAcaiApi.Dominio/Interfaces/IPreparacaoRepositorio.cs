using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dominio.Interfaces
{
   public interface IPreparacaoRepositorio
    {
        List<Preparacao> ObterTodos();

        Preparacao ObterPorSaborTamanho(int saborId, int tamanhoId);

        Preparacao ObterPorId(int id);

        Preparacao Incluir(Preparacao preparacao);

        Preparacao Editar(Preparacao preparacao);

        void Excluir(int id);

        bool Existe(int id);
    }
}
