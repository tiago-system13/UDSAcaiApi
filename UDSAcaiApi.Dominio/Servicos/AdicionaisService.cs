using System;
using System.Collections.Generic;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Interfaces;
using UDSAcaiApi.Dominio.Servicos.Interfaces;

namespace UDSAcaiApi.Dominio.Servicos
{
    public class AdicionaisService : IAdicionaisService
    {
        private readonly IAdicionaisRepositorio _repositorioAdicionais;

        public AdicionaisService(IAdicionaisRepositorio repositorioAdicionais)
        {
            _repositorioAdicionais = repositorioAdicionais;
        }
        public Adicionais Editar(Adicionais Adicionais)
        {
            var AdicionaisDb = _repositorioAdicionais.Editar(Adicionais);

            if (AdicionaisDb == null)
            {
                throw new ArgumentException("Adicionais não encontrado!");
            }

            return AdicionaisDb;
        }

        public Adicionais ObterPorId(int id)
        {
            var AdicionaisDb = _repositorioAdicionais.ObterPorId(id);

            if (AdicionaisDb == null)
            {
                throw new ArgumentException("Adicionais não encontrado!");
            }

            return AdicionaisDb;
        }

        public void Excluir(int id)
        {
            if (!_repositorioAdicionais.Existe(id))
            {
                throw new ArgumentException("Adicionais não encontrado!");
            }

            _repositorioAdicionais.Excluir(id);
        }

        public Adicionais Incluir(Adicionais Adicionais)
        {
            return _repositorioAdicionais.Incluir(Adicionais);
        }

        public List<Adicionais> ObterTodos()
        {
            return _repositorioAdicionais.ObterTodos();
        }
    }
}
