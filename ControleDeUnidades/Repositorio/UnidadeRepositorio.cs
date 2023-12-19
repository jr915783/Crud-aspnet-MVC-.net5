using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
    public class UnidadeRepositorio : IUnidadeRepositorio
    {
        private readonly BancoContent _context;

        public UnidadeRepositorio(BancoContent bancoContent)
        {
            this._context = bancoContent;
        }        

        public UnidadeModel BuscarPorID(int id)
        {
            return _context.Unidades.Include(x => x.Colaboradores).FirstOrDefault(x => x.Id == id);
        }

        public List<UnidadeModel> BuscarTodos()
        {
            return _context.Unidades
                .Include(x => x.Colaboradores)
                .ToList();
        }

        public List<UnidadeModel> BuscarUnidadesAtivas()
        {
            return _context.Unidades.Where(x => x.Status == Enums.StatusEnum.Ativo).ToList();
        }


        public UnidadeModel Adicionar(UnidadeModel unidade)
        {           
            _context.Unidades.Add(unidade);
            _context.SaveChanges();
            return unidade;
        }

        public UnidadeModel Atualizar(UnidadeModel unidade)
        {
            UnidadeModel unidadeDB = BuscarPorID(unidade.Id);

            if (unidadeDB == null) throw new Exception("Houve um erro na atualização da unidade!");

            unidadeDB.Nome = unidade.Nome;   
            unidadeDB.Status = unidade.Status;
           

            _context.Unidades.Update(unidadeDB);
            _context.SaveChanges();

            return unidadeDB;
        }        

        public bool Apagar(int id)
        {
            UnidadeModel usuarioDB = BuscarPorID(id);

            if (usuarioDB == null) throw new Exception("Houve um erro na deleção da unidade!");

            if(usuarioDB.Colaboradores.Count >= 1)
            {
                throw new Exception("Não é possível apagar unidade que tenha colaboradores!");
            }

            _context.Unidades.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }
    }
}
