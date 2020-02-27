using System.Collections.Generic;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dominio.Servicos.Interfaces
{
    public interface IAdicionaisService
    {
        List<Adicionais> ObterTodos();

        Adicionais Incluir(Adicionais adicionais);

        Adicionais Editar(Adicionais adicionais);

        Adicionais ObterPorId(int id);

        void Excluir(int id);
    }
}
