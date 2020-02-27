using System;
using System.Collections.Generic;
using System.Text;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Interfaces;
using UDSAcaiApi.Dominio.Servicos.Interfaces;

namespace UDSAcaiApi.Dominio.Servicos
{
    public class TamanhoService: ITamanhoService
    {
        private readonly ITamanhoRepositorio _repositorioTamanho;

        public TamanhoService(ITamanhoRepositorio repositorioTamanho)
        {
            _repositorioTamanho = repositorioTamanho;
        }
        public Tamanho Editar(Tamanho Tamanho)
        {
            var TamanhoDb = _repositorioTamanho.Editar(Tamanho);

            if (TamanhoDb == null)
            {
                throw new ArgumentException("Tamanho não encontrado!");
            }

            return TamanhoDb;
        }

        public void Excluir(int id)
        {
            if (!_repositorioTamanho.Existe(id))
            {
                throw new ArgumentException("Tamanho não encontrado!");
            }

            _repositorioTamanho.Excluir(id);
        }

        public Tamanho Incluir(Tamanho Tamanho)
        {
            return _repositorioTamanho.Incluir(Tamanho);
        }

        public List<Tamanho> ObterTodos()
        {
            return _repositorioTamanho.ObterTodos();
        }
    }
}
