using Sisteminha.Helper;
using Sisteminha.Models;
using Sisteminha.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Sisteminha.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel) 
        {    
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscaSessaoUsuario();
                alterarSenhaModel.Id = usuarioLogado.Id;
                if (ModelState.IsValid) 
                {
                    _usuarioRepository.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha Alterada com Sucesso";
                    return View("Index", alterarSenhaModel);
                }
                return View("Index",alterarSenhaModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não Conseguimos Alterar sua Senha, Tente Novamente, Detalhe do erro: {erro.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
