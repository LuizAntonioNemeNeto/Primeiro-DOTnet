using Sisteminha.Models;

namespace Sisteminha.Repositorys
{
    public interface IConsultaRepository
    {
        ConsultaModel ListarPorId(int id);
        List<ConsultaModel> BuscarTodos();
        List<ConsultaModel> BuscarTodosMedicos(int medicoId);
        List<ConsultaModel> BuscarTodosPacientes(int pacienteId);
        ConsultaModel Adicionar(ConsultaModel consulta);
        ConsultaModel Atualizar(ConsultaModel consulta);
        bool Excluir(int id);
    }
}
