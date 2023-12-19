using ControleDeContatos.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Repositorio
{
    public interface IColaboradorRepositorio
    {
        List<ColaboradorModel> BuscarTodos();
        List<ColaboradorModel> BuscarTodosPorUnidade(int id);
        ColaboradorModel BuscarPorID(int id);
        ColaboradorModel Adicionar(ColaboradorModel colaborador);
        ColaboradorModel Atualizar(ColaboradorModel colaborador);
        bool Apagar (int id);
    }
}
