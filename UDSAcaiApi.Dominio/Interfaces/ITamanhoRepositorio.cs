using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dominio.Interfaces
{
   public interface ITamanhoRepositorio
    {
        List<Tamanho> ObterTodos();

        Tamanho Incluir(Tamanho sabor);

        Tamanho Editar(Tamanho sabor);

        void Excluir(int id);

        bool Existe(int id);
    }
}
