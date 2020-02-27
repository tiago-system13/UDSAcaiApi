using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Interfaces;
using UDSAcaiApi.Dominio.Servicos.Interfaces;

namespace UDSAcaiApi.Dominio.Servicos
{
    public class PreparacaoService:IPreparacaoService
    {
        private readonly IPreparacaoRepositorio _repositorioPreparacao;

        private const int ID_SABOR_KIWI = 3;

        private static TimeSpan ACRESCIMENTO_TEMPO_SABOR_KIWI = TimeSpan.Parse("00:05:00");
        public PreparacaoService(IPreparacaoRepositorio repositorioPreparacao)
        {
            _repositorioPreparacao = repositorioPreparacao;
        }
        public Preparacao Editar(Preparacao Preparacao)
        {
            var PreparacaoDb = _repositorioPreparacao.Editar(Preparacao);

            if (PreparacaoDb == null)
            {
                throw new ArgumentException("Preparacao não encontrado!");
            }

            return PreparacaoDb;
        }

        public Preparacao ObterPorId(int id)
        {
            var PreparacaoDb = _repositorioPreparacao.ObterPorId(id);

            if (PreparacaoDb == null)
            {
                throw new ArgumentException("Preparacao não encontrado!");
            }

            return PreparacaoDb;
        }

        public Preparacao ObterPorSaborTamanho(int saborId, int tamanhoId)
        {
            var PreparacaoDb = _repositorioPreparacao.ObterPorSaborTamanho(saborId,tamanhoId);

            if (PreparacaoDb == null)
            {
                throw new ArgumentException("Preparacao não encontrado!");
            }

            return PreparacaoDb;
        }

        public void Excluir(int id)
        {
            if (!_repositorioPreparacao.Existe(id))
            {
                throw new ArgumentException("Preparacao não encontrado!");
            }

            _repositorioPreparacao.Excluir(id);
        }
        private bool ExistePreparaPorSaborTamanho(int saborId, int tamanhoId)
        {
            return _repositorioPreparacao.ObterPorSaborTamanho(saborId, tamanhoId) != null;
        }

        public Preparacao Incluir(Preparacao Preparacao)
        {
            if (ExistePreparaPorSaborTamanho(Preparacao.SaborId, Preparacao.TamanhoId))
            {
                throw new ArgumentException("Já existe preparação cadastrada com o sabor e tamanho informado!");
            }

            if (Preparacao.SaborId == ID_SABOR_KIWI)
            {
                Preparacao.Tempo = AcrescentarTempoPreparacao(Preparacao);
            }

            return _repositorioPreparacao.Incluir(Preparacao);
        }

        private TimeSpan AcrescentarTempoPreparacao(Preparacao Preparacao)
        {
            return Preparacao.Tempo + ACRESCIMENTO_TEMPO_SABOR_KIWI;
        }

        public List<Preparacao> ObterTodos()
        {
            return _repositorioPreparacao.ObterTodos();
        }
    }
}
