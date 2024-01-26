using Microsoft.AspNetCore.Mvc;
using Sisteminha.Filters;
using Sisteminha.Models;
using Sisteminha.Repositorys;

namespace Sisteminha.Controllers
{
    [PaginaUsuarioLogado]
    public class MedicoController : Controller
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IConsultaRepository _consultaRepository;
        public MedicoController(IMedicoRepository medicoRepository, IConsultaRepository consultaRepository)
        {
            _medicoRepository = medicoRepository;
            _consultaRepository = consultaRepository;

        }
        public IActionResult Index()
        {
            List<MedicoModel> medicos = _medicoRepository.BuscarTodos();
            return View(medicos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            MedicoModel medico = _medicoRepository.ListarPorId(id);
            return View(medico);
        }
        public IActionResult Apagar(int id)
        {
            MedicoModel medico = _medicoRepository.ListarPorId(id);
            return View(medico);
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                bool apagado = _medicoRepository.Excluir(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Médico Apagado com Sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não Conseguimos Apagar o Médico";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não Conseguimos Apagar o Médico, Tente Novamente, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult ListarConsultasPorMedicoId(int id)
        {
            List<ConsultaModel> consultas = _consultaRepository.BuscarTodosMedicos(id);
            return PartialView("_ConsultaMedico", consultas);
        }

        [HttpPost]
        public IActionResult Criar(MedicoModel medico)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _medicoRepository.Adicionar(medico);
                    TempData["MensagemSucesso"] = "Médico Cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }
                return View(medico);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não Conseguimos Cadastrar o Médico, Tente Novamente, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(MedicoModel medico)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _medicoRepository.Atualizar(medico);
                    TempData["MensagemSucesso"] = "Médico Alterado com Sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", medico);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não Conseguimos Alterar o Médico, Tente Novamente, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
