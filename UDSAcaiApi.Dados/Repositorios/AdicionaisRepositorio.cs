using System.Collections.Generic;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Interfaces;

namespace UDSAcaiApi.Dados.Repositorios
{
    public class AdicionaisRepositorio : IAdicionaisRepositorio
    {
        private readonly IRepositorioBase<Adicionais> _repositorioAdicionais;

        public AdicionaisRepositorio(IRepositorioBase<Adicionais> repositorioAdicionais)
        {
            _repositorioAdicionais = repositorioAdicionais;
        }
        public Adicionais Editar(Adicionais Adicionais)
        {
            return _repositorioAdicionais.Editar(Adicionais);
        }

        public Adicionais ObterPorId(int id)
        {
            return _repositorioAdicionais.ObterPorId(id);
        }

        public void Excluir(int id)
        {
            _repositorioAdicionais.Excluir(id);
        }

        public bool Existe(int id)
        {
            return _repositorioAdicionais.Existe(id);
        }

        public Adicionais Incluir(Adicionais Adicionais)
        {
            return _repositorioAdicionais.Incluir(Adicionais);
        }

        public List<Adicionais> ObterTodos()
        {
            return _repositorioAdicionais.Todos();
        }
    }
}
