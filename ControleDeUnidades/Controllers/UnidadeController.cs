using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    //[PaginaRestritaSomenteAdmin]
    public class UnidadeController : Controller
    {
        private readonly IUnidadeRepositorio _unidadeRepositorio;
        private readonly IColaboradorRepositorio _colaboradorRepositorio;

        public UnidadeController(IUnidadeRepositorio unidadeRepositorio,
                                 IColaboradorRepositorio colaboradorRepositorio)
        {
            _unidadeRepositorio = unidadeRepositorio;
            _colaboradorRepositorio = colaboradorRepositorio;
        }

        public IActionResult Index()
        {
            List<UnidadeModel> unidades = _unidadeRepositorio.BuscarTodos();

            return View(unidades);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UnidadeModel unidade = _unidadeRepositorio.BuscarPorID(id);
            return View(unidade);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UnidadeModel unidade = _unidadeRepositorio.BuscarPorID(id);
            return View(unidade);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _unidadeRepositorio.Apagar(id);

                if (apagado) TempData["MensagemSucesso"] = "Unidade apagada com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos apagar sua unidade, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar sua unidade, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ListarColaboradorPorUnidade(int id)
        {
            List<ColaboradorModel> colaboradores = _colaboradorRepositorio.BuscarTodosPorUnidade(id);
            return PartialView("_ColaboradoresUnidade", colaboradores);
        }

        [HttpPost]
        public IActionResult Criar(UnidadeModel unidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unidade = _unidadeRepositorio.Adicionar(unidade);

                    TempData["MensagemSucesso"] = "Unidade cadastrada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(unidade);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar sua Unidade, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UnidadeModel unidadeModel)
        {
            try
            {
                UnidadeModel unidade = null;

                if (ModelState.IsValid)
                {
                    unidade = new UnidadeModel()
                    {
                        Id = unidadeModel.Id,
                        Nome = unidadeModel.Nome,
                        Status = unidadeModel.Status
                    };

                    unidade = _unidadeRepositorio.Atualizar(unidade);
                    TempData["MensagemSucesso"] = "Unidade alterada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(unidade);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar sua unidade, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ModalApagarUnidade(int id)
        {
            UnidadeModel unidade = _unidadeRepositorio.BuscarPorID(id);
            return PartialView("_ApagarConfirmacao", unidade);
        }

        public IActionResult BuscarUnidadesAtivas()
        {
            List<UnidadeModel> unidades = _unidadeRepositorio.BuscarTodos();

            return View(unidades);
        }
    }
}
