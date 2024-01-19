using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sisteminha.Data;
using Sisteminha.Filters;
using Sisteminha.Models;
using Sisteminha.Repositorys;

namespace Sisteminha.Controllers
{
    [PaginaUsuarioLogado]
    public class ConsultaController : Controller
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IConsultaRepository _consultaRepository;
        private readonly IPacienteRepository _pacienteRepository;
        public ConsultaController(IConsultaRepository consultaRepository, IMedicoRepository medicoRepository, IPacienteRepository pacienteRepository)
        {
            _consultaRepository = consultaRepository;
            _medicoRepository = medicoRepository;
            _pacienteRepository = pacienteRepository;
        }
        public IActionResult Index()
        {
            List<ConsultaModel> consultas = _consultaRepository.BuscarTodos();
            return View(consultas);
        }
        public IActionResult Criar()
        {
            var med = _medicoRepository.BuscarTodos().ToList();
            var pac = _pacienteRepository.BuscarTodos().ToList();
            ViewBag.Medicos = new SelectList(med, "Id", "Nome");
            ViewBag.Pacientes = new SelectList(pac, "Id", "Nome");
            return View();
        }
        public IActionResult Editar(int id)
        {
            ConsultaModel consulta = _consultaRepository.ListarPorId(id);
            var med = _medicoRepository.BuscarTodos().ToList();
            var pac = _pacienteRepository.BuscarTodos().ToList();
            ViewBag.Medicos = new SelectList(med, "Id", "Nome");
            ViewBag.Pacientes = new SelectList(pac, "Id", "Nome");
            return View(consulta);
        }
        public IActionResult Apagar(int id)
        {
            ConsultaModel consulta = _consultaRepository.ListarPorId(id);
            return View(consulta);
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                bool apagado = _consultaRepository.Excluir(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Consulta Apagado com Sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não Conseguimos Apagar a Consulta";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não Conseguimos Apagar a Consulta, Tente Novamente, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(ConsultaModel consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _consultaRepository.Adicionar(consulta);
                    TempData["MensagemSucesso"] = "Consulta Cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }
                return View(consulta);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não Conseguimos Cadastrar a Consulta, Tente Novamente, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(ConsultaModel consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _consultaRepository.Atualizar(consulta);
                    TempData["MensagemSucesso"] = "Consulta Alterado com Sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", consulta);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não Conseguimos Alterar a Consulta, Tente Novamente, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
