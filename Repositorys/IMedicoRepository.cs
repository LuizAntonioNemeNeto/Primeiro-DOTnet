using Sisteminha.Models;

namespace Sisteminha.Repositorys
{
    public interface IMedicoRepository
    {
        MedicoModel ListarPorId(int id);
        List<MedicoModel> BuscarTodos();
        MedicoModel Adicionar(MedicoModel medico);
        MedicoModel Atualizar(MedicoModel medico);
        bool Excluir(int id);
    }
}
