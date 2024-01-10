using Sisteminha.Models;

namespace Sisteminha.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel BuscaPorEmail(string email);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        bool Excluir(int id);
    }
}
