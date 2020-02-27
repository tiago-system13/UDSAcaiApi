using System.Collections.Generic;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Interfaces;

namespace UDSAcaiApi.Dados.Repositorios
{
    public class TamanhoRepositorio: ITamanhoRepositorio
    {
        private readonly IRepositorioBase<Tamanho> _repositorioTamanho;

        public TamanhoRepositorio(IRepositorioBase<Tamanho> repositorioTamanho)
        {
            _repositorioTamanho = repositorioTamanho;
        }
        public Tamanho Editar(Tamanho Tamanho)
        {
            return _repositorioTamanho.Editar(Tamanho);
        }

        public Tamanho ObterPorId(int id)
        {
            return _repositorioTamanho.ObterPorId(id);
        }

        public void Excluir(int id)
        {
            _repositorioTamanho.Excluir(id);
        }

        public bool Existe(int id)
        {
            return _repositorioTamanho.Existe(id);
        }

        public Tamanho Incluir(Tamanho Tamanho)
        {
            return _repositorioTamanho.Incluir(Tamanho);
        }

        public List<Tamanho> ObterTodos()
        {
            return _repositorioTamanho.Todos();
        }
    }
}
