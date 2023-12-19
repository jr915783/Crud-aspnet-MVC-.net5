using ControleDeContatos.Filters;
using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{

    [PaginaParaUsuarioLogado]
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorRepositorio _colaboradorRepositorio;
        private readonly IUnidadeRepositorio _unidadeRepositorio;
        private readonly ISessao _sessao;

        public ColaboradorController(IColaboradorRepositorio colaboradorRepositorio,
                                 ISessao sessao, IUnidadeRepositorio unidadeRepositorio)
        {
            _colaboradorRepositorio = colaboradorRepositorio;
            _sessao = sessao;
            _unidadeRepositorio = unidadeRepositorio;
        }

        public IActionResult Index()
        {           
            List<ColaboradorModel> colaboradores = _colaboradorRepositorio.BuscarTodos();

            return View(colaboradores);
        }

        public IActionResult Criar()
        {           
            ViewBag.ListaDeUnidades = _unidadeRepositorio.BuscarUnidadesAtivas();
            return View();
        }

        public IActionResult Editar(int id)
        {
            ColaboradorModel colaborador = _colaboradorRepositorio.BuscarPorID(id);
            ViewBag.ListaDeUnidades = _unidadeRepositorio.BuscarTodos();
            return View(colaborador);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ColaboradorModel colaborador = _colaboradorRepositorio.BuscarPorID(id);
            return View(colaborador);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _colaboradorRepositorio.Apagar(id);

                if(apagado) TempData["MensagemSucesso"] = "colaborador apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos apagar seu colaborador, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu colaborador, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ColaboradorModel colaborador)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    colaborador = _colaboradorRepositorio.Adicionar(colaborador);

                    TempData["MensagemSucesso"] = "colaborador cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                ViewBag.ListaDeUnidades = _unidadeRepositorio.BuscarUnidadesAtivas();
                return View(colaborador);
            }
            catch (Exception erro)
            { 
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu colaborador, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(ColaboradorModel colaborador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    colaborador = _colaboradorRepositorio.Atualizar(colaborador);
                    TempData["MensagemSucesso"] = "Colaborador alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(colaborador);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu colaborador, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ModalApagarColaborador(int id)
        {
            ColaboradorModel colaboradores = _colaboradorRepositorio.BuscarPorID(id);
            return PartialView("_ApagarConfirmacao", colaboradores);
        }
    }
}
