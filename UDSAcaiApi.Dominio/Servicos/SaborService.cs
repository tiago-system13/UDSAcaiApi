using System;
using System.Collections.Generic;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Interfaces;
using UDSAcaiApi.Dominio.Servicos.Interfaces;

namespace UDSAcaiApi.Dominio.Servicos
{
    public class SaborService : ISaborService
    {
        private readonly ISaborRepositorio _repositorioSabor;

        public SaborService(ISaborRepositorio repositorioSabor)
        {
            _repositorioSabor = repositorioSabor;
        }
        public Sabor Editar(Sabor sabor)
        {
            var saborDb = _repositorioSabor.Editar(sabor);

            if (saborDb == null)
            {
                throw new ArgumentException("Sabor não encontrado!");
            }

            return saborDb;
        }

        public Sabor ObterPorId(int id)
        {
            var saborDb = _repositorioSabor.ObterPorId(id);

            if (saborDb == null)
            {
                throw new ArgumentException("Sabor não encontrado!");
            }

            return saborDb;
        }



        public void Excluir(int id)
        {
            if (!_repositorioSabor.Existe(id))
            {
                throw new ArgumentException("Sabor não encontrado!");
            }

            _repositorioSabor.Excluir(id);
        }

        public Sabor Incluir(Sabor sabor)
        {
            return _repositorioSabor.Incluir(sabor);
        }

        public List<Sabor> ObterTodos()
        {
            return _repositorioSabor.ObterTodos();
        }
    }
}
