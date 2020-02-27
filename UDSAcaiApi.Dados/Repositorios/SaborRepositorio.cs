using System.Collections.Generic;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Interfaces;

namespace UDSAcaiApi.Dados.Repositorios
{
    public class SaborRepositorio : ISaborRepositorio
    {
        private readonly IRepositorioBase<Sabor> _repositorioSabor;

        public SaborRepositorio(IRepositorioBase<Sabor> repositorioSabor)
        {
            _repositorioSabor = repositorioSabor;
        }
        public Sabor Editar(Sabor sabor)
        {
            return _repositorioSabor.Editar(sabor); 
        }

        public Sabor ObterPorId(int id)
        {
            return _repositorioSabor.ObterPorId(id);
        }

        public void Excluir(int id)
        {
            _repositorioSabor.Excluir(id);
        }

        public bool Existe(int id)
        {
            return _repositorioSabor.Existe(id);
        }

        public Sabor Incluir(Sabor sabor)
        {
          return  _repositorioSabor.Incluir(sabor);
        }

        public List<Sabor> ObterTodos()
        {
          return  _repositorioSabor.Todos();
        }
    }
}
