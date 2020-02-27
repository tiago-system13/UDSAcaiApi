using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UDSAcaiApi.Dados.Contexto;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Interfaces;

namespace UDSAcaiApi.Dados.Repositorios
{
    public class PreparacaoRepositorio : IPreparacaoRepositorio
    {
        private readonly IRepositorioBase<Preparacao> _repositorioPreparacao;
        private readonly UDSAcaiApiContext _contexto;

        public PreparacaoRepositorio(IRepositorioBase<Preparacao> repositorioPreparacao, UDSAcaiApiContext contexto)
        {
            _repositorioPreparacao = repositorioPreparacao;
            _contexto = contexto;
        }
        public Preparacao Editar(Preparacao Preparacao)
        {
            return _repositorioPreparacao.Editar(Preparacao);
        }

        public Preparacao ObterPorId(int id)
        {
            return _contexto.Preparacoes.Include(p => p.Sabor)
                                        .Include(p => p.Tamanho)
                                        .FirstOrDefault(prop => prop.Id == id);
        }

        public Preparacao ObterPorSaborTamanho(int saborId, int tamanhoId)
        {
            return _contexto.Preparacoes.Include(p => p.Sabor)
                                        .Include(p => p.Tamanho)
                                        .FirstOrDefault(prop => prop.SaborId == saborId && prop.TamanhoId == tamanhoId);
        }

        public void Excluir(int id)
        {
            _repositorioPreparacao.Excluir(id);
        }

        public bool Existe(int id)
        {
            return _repositorioPreparacao.Existe(id);
        }

        public Preparacao Incluir(Preparacao Preparacao)
        {
            return _repositorioPreparacao.Incluir(Preparacao);
        }

        public List<Preparacao> ObterTodos()
        {
            return _repositorioPreparacao.Todos();
        }

    }
}
