using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dominio.Interfaces
{
    public interface ISaborRepositorio
    {
        List<Sabor> ObterTodos();

        Sabor Incluir(Sabor sabor);

        Sabor Editar(Sabor sabor);

        Sabor ObterPorId(int id);

        void Excluir(int id);

        bool Existe(int id);

    }
}
