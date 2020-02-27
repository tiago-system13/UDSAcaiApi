using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades.Base;

namespace UDSAcaiApi.Dominio.Interfaces
{
    public interface IRepositorioBase<T> where T : EntidadeBase
    {
        T Incluir(T item);
        T ObterPorId(int id);
        List<T> Todos();
        T Editar(T item);
        void Excluir(int id);

        bool Existe(int? id);
    }
}
