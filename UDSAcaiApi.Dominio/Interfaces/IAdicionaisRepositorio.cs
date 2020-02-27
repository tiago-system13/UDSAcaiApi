using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dominio.Interfaces
{
    public interface IAdicionaisRepositorio
    {
        List<Adicionais> ObterTodos();

        Adicionais Incluir(Adicionais Adicionais);

        Adicionais Editar(Adicionais Adicionais);

        Adicionais ObterPorId(int id);

        void Excluir(int id);

        bool Existe(int id);
    }
}
