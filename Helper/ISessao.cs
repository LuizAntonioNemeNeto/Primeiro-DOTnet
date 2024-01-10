using Sisteminha.Models;

namespace Sisteminha.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuario();
        UsuarioModel BuscaSessaoUsuario();
    }
}
