using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
    public class ColaboradorRepositorio : IColaboradorRepositorio
    {
        private readonly BancoContent _context;

        public ColaboradorRepositorio(BancoContent bancoContent)
        {
            this._context = bancoContent;
        }

        public ColaboradorModel BuscarPorID(int id)
        {
            return _context.Colaboradores.FirstOrDefault(x => x.Id == id);
        }

        public List<ColaboradorModel> BuscarTodos()
        {
            IQueryable<ColaboradorModel> query = _context.Colaboradores.Include(x => x.Unidade);
            return query.ToList();
        }

        public List<ColaboradorModel> BuscarTodosPorUnidade(int id)
        {
            IQueryable<ColaboradorModel> query = _context.Colaboradores.Where(x => x.UnidadeId == id).Include(x => x.Unidade);
            return query.ToList();
        }

        public ColaboradorModel Adicionar(ColaboradorModel colaborador)
        {
            _context.Colaboradores.Add(colaborador);
            _context.SaveChanges();
            return colaborador;
        }

        public ColaboradorModel Atualizar(ColaboradorModel colaborador)
        {
            ColaboradorModel colaboradorDB = BuscarPorID(colaborador.Id);

            if (colaboradorDB == null) throw new Exception("Houve um erro na atualização do colaborador!");

            colaboradorDB.Nome = colaborador.Nome;
            colaboradorDB.UnidadeId = colaborador.UnidadeId;

            _context.Colaboradores.Update(colaboradorDB);
            _context.SaveChanges();

            return colaboradorDB;
        }

        public bool Apagar(int id)
        {
            ColaboradorModel colaboradorDB = BuscarPorID(id);

            if (colaboradorDB == null) throw new Exception("Houve um erro na deleção do colaborador!");

            _context.Colaboradores.Remove(colaboradorDB);
            _context.SaveChanges();

            return true;
        }
    }
}
