using Microsoft.AspNetCore.Mvc;
using Sisteminha.Filters;
using Sisteminha.Helper;
using Sisteminha.Models;
using Sisteminha.Repositorys;

namespace Sisteminha.Controllers
{
    [PaginaUsuarioLogado]
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly ISessao _sessao;
        public PacienteController(IPacienteRepository pacienteRepository,ISessao sessao)
        {
            _pacienteRepository = pacienteRepository;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            List<PacienteModel> pacientes = _pacienteRepository.BuscarTodos();
            return View(pacientes);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            PacienteModel paciente = _pacienteRepository.ListarPorId(id);
            return View(paciente);
        }
        public IActionResult Apagar(int id)
        {
            PacienteModel paciente = _pacienteRepository.ListarPorId(id);
            return View(paciente);
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                bool apagado = _pacienteRepository.Excluir(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Paciente Apagado com Sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não Conseguimos Apagar o Paciente";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não Conseguimos Apagar o Paciente, Tente Novamente, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(PacienteModel paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _pacienteRepository.Adicionar(paciente);
                    TempData["MensagemSucesso"] = "Paciente Cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }
                return View(paciente);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não Conseguimos Cadastrar o Paciente, Tente Novamente, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(PacienteModel paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _pacienteRepository.Atualizar(paciente);
                    TempData["MensagemSucesso"] = "Paciente Alterado com Sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", paciente);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não Conseguimos Alterar o Paciente, Tente Novamente, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
