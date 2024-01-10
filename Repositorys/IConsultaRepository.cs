using Sisteminha.Models;

namespace Sisteminha.Repositorys
{
    public interface IConsultaRepository
    {
        ConsultaModel ListarPorId(int id);
        List<ConsultaModel> BuscarTodos();
        ConsultaModel Adicionar(ConsultaModel consulta);
        ConsultaModel Atualizar(ConsultaModel consulta);
        bool Excluir(int id);
    }
}
