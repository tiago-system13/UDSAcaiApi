﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDSAcaiApi.Dados.Contexto;
using UDSAcaiApi.Dominio.Entidades.Base;
using UDSAcaiApi.Dominio.Interfaces;

namespace UDSAcaiApi.Dados.Repositorios
{
   public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadeBase
    {

        private readonly UDSAcaiApiContext _context;

        // Declaração de um dataset genérico
        private DbSet<T> dataset;

        public RepositorioBase(UDSAcaiApiContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }


        public T Incluir(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(int id)
        {
            var result = dataset.SingleOrDefault(i => i.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Existe(int? id)
        {
            return dataset.Any(b => b.Id.Equals(id));
        }

        public List<T> Todos()
        {
            return dataset.ToList();
        }

        public T ObterPorId(int id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Editar(T item)
        {
            if (!Existe(item.Id)) return null;

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = dataset.SingleOrDefault(b => b.Id == item.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
    }
}
