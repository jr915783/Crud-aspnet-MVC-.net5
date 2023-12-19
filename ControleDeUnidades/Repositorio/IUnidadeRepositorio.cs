using ControleDeContatos.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Repositorio
{
    public interface IUnidadeRepositorio
    {   
        List<UnidadeModel> BuscarTodos();        
        UnidadeModel BuscarPorID(int id);
        UnidadeModel Adicionar(UnidadeModel unidade);
        UnidadeModel Atualizar(UnidadeModel unidade);
        List<UnidadeModel> BuscarUnidadesAtivas();
        bool Apagar (int id);
    }
}
