using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dominio.Servicos.Interfaces
{
    public interface ITamanhoService
    {
        List<Tamanho> ObterTodos();

        Tamanho Incluir(Tamanho sabor);

        Tamanho Editar(Tamanho sabor);

        void Excluir(int id);
    }
}
